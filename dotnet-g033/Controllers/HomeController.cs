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

namespace dotnet_g033.Controllers
{
    public class HomeController : Controller
    {

        #region Fields
        private readonly ILogger<HomeController> _logger;
        private readonly ISessieRepository _sessieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, ISessieRepository sessieRepository, IGebruikerRepository gebruikerRepository)
        {
            _logger = logger;
            _sessieRepository = sessieRepository;
            _gebruikerRepository = gebruikerRepository;

        }
        #endregion

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker)
        {
            if (gebruiker != null)
            {


            }
            return View();
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
