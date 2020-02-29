using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g033.Filters;
using dotnet_g033.Models.Domain;
using dotnet_g033.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_g033.Controllers
{
    public class SessieController : Controller {
        private readonly ISessieRepository _sessieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        public SessieController(ISessieRepository sessieRepository , IGebruikerRepository gebruikerRepository)
        {
            this._sessieRepository = sessieRepository;
            this._gebruikerRepository = gebruikerRepository;
        }
        [ServiceFilter(typeof(GebruikerFilter))]
        public ActionResult Index(Gebruiker gebruiker,int maandId=0) {
            if (maandId == 0)
            {
                maandId = DateTime.Now.Month;
            }
            HashSet<Sessie> hashSessies = _sessieRepository.GetByMaand(maandId).ToHashSet();
            if (gebruiker != null)
            {
                switch (gebruiker.Type)
                {
                    case GebruikerType.Gebruiker:
                        hashSessies = _sessieRepository.GetByMaand(maandId).ToHashSet();
                        break;
                    case GebruikerType.Verantwoordelijke:
                        hashSessies = _sessieRepository.GetByMaandVerantwoordelijke(maandId).ToHashSet();
                        break;
                    case GebruikerType.HoofdVerantwoordelijke:
                        hashSessies = _sessieRepository.GetByMaandVerantwoordelijke(maandId).ToHashSet();
                        break;
                }
                ViewData["bevatSessies"] = !hashSessies.Any();
                ViewData["Ingelogd"] = true;
            }
            else {
                ViewData["bevatSessies"] = true;
                ViewData["Ingelogd"] = false;
            }
            IEnumerable<Sessie> sessies = new List<Sessie>(hashSessies);
            ViewData["Maanden"] = GetMaandSelectList(maandId);
            return View(sessies);
        }

        public ActionResult Details(int id) {
            Sessie sessie = _sessieRepository.GetById(id);
            var viewModel = new SessieDetailsViewModel(sessie);
            return View(viewModel);
        }
        

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult SchrijfIn(int sessieId, SessieDetailsViewModel viewModel,Gebruiker gebruiker) {
            if (ModelState.IsValid) {
                try {
                    Sessie sessie = _sessieRepository.GetById(sessieId);
                    TempData["message"] = $"Je reservatie voor {sessie.Naam} op werd geregistreerd...";
                }
                catch(Exception e) {
                    TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet inschrijven...";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        private SelectList GetMaandSelectList(int maandId = 0)
        {
            var maanden = from Maand m in Enum.GetValues(typeof(Maand)) select new { ID = (int)m, Name = m.ToString() };
            return new SelectList(maanden, "ID", "Name", maandId);
        }
    }
}