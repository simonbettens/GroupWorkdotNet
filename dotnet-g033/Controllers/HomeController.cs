using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnet_g033.Models;
using dotnet_g033.Models.Domain;
using dotnet_g033.Filters;
using dotnet_g033.Models.ViewModels;

namespace dotnet_g033.Controllers
{
    public class HomeController : Controller
    {

        #region Fields
        private readonly ILogger<HomeController> _logger;
        private readonly ISessieRepository _sessieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly IAankondigingRepository _aankondigingRepository;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, ISessieRepository sessieRepository, 
            IGebruikerRepository gebruikerRepository,IAankondigingRepository aankondigingRepository)
        {
            _logger = logger;
            _sessieRepository = sessieRepository;
            _gebruikerRepository = gebruikerRepository;
            _aankondigingRepository = aankondigingRepository;

        }
        #endregion

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker)
        {
            IEnumerable<SessieAankondiging> sessieAankondingen = new List<SessieAankondiging>();
            Sessie sessie = _sessieRepository.GetByMaand(DateTime.Now.Month).FirstOrDefault();
            bool ingelogd = false;
            if (gebruiker != null)
            {
                ingelogd = true;
                foreach (var inschrijving in gebruiker.SessiesIngeschreven)
                {
                    sessieAankondingen = sessieAankondingen.Concat(_aankondigingRepository.GetAllSessieAankonding(inschrijving.SessieId));
                }

            }
            sessieAankondingen = sessieAankondingen.OrderByDescending(sa => sa.Prioriteit).ThenBy(sa => sa.Gepost);
            if (sessie != null)
            {
                bool ingeschreven = false;
                if (gebruiker != null)
                {
                    ingeschreven = sessie.GebruikerIsIngeschreven(gebruiker);
                }
                ViewData["IsIngeschreven"] = ingeschreven;
                if (ingeschreven)
                {
                    ViewData["IsAanwezig"] = sessie.GeefSessieGebruiker(gebruiker).Aanwezig;
                }
                else
                {
                    ViewData["IsAanwezig"] = false;
                }

            }
            IEnumerable<Aankondiging> algemeneAankondingen = _aankondigingRepository.GetAllAlgemene().ToList().OrderByDescending(a=>a.Prioriteit).ThenBy(a=>a.Gepost);
            HomeIndexViewModel hivm = new HomeIndexViewModel(algemeneAankondingen, sessieAankondingen, sessie,ingelogd); 
            return View(hivm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
