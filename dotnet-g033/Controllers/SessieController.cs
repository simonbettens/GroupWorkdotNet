using dotnet_g033.Filters;
using dotnet_g033.Models.Domain;
using dotnet_g033.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_g033.Controllers
{
    
    [Authorize]
        public class SessieController : Controller
    {

        #region Repositories

        private readonly ISessieRepository _sessieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        #endregion

        #region Constructor
        public SessieController(ISessieRepository sessieRepository, IGebruikerRepository gebruikerRepository)
        {
            this._sessieRepository = sessieRepository;
            this._gebruikerRepository = gebruikerRepository;
        }

        #endregion

        #region Index & Details

        [ServiceFilter(typeof(GebruikerFilter))]

        public ActionResult Index(Gebruiker gebruiker, int maandId = 0)
        {
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
            else
            {
                ViewData["bevatSessies"] = true;
                ViewData["Ingelogd"] = false;
            }
            IEnumerable<Sessie> sessies = new List<Sessie>(hashSessies);
            ViewData["Maanden"] = GetMaandSelectList(maandId);
            SessieIndexViewmodel viewmodel = new SessieIndexViewmodel(gebruiker, sessies);
            return View(viewmodel);
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public ActionResult Details(int id, Gebruiker gebruiker)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (sessie != null)
            {
                bool ingeschreven = sessie.GebruikerIsIngeschreven(gebruiker);
                ViewData["IsIngeschreven"] = ingeschreven;
                if (ingeschreven)
                {
                    ViewData["IsAanwezig"] = sessie.GeefSessieGebruiker(gebruiker).Aanwezig;
                }
                else
                {
                    ViewData["IsAanwezig"] = false;
                }
                var viewModel = new SessieDetailsViewModel(sessie);
                return View(viewModel);
            }
            TempData["error"] = "Sorry, er is iets mis gegaan, we konden de sessie niet ophalen...";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Inschrijven & Uitschrijven & Aanwezig Stellen & Afwezig Stellen

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult InSchrijven(int id, Gebruiker gebruiker)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (gebruiker != null && sessie != null)
            {
                try
                {
                    SessieGebruiker sessieGebruiker = new SessieGebruiker(sessie, gebruiker);
                    sessie.SchrijfGebruikerIn(sessieGebruiker, gebruiker);
                    _gebruikerRepository.SaveChanges();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je inschrijving voor {sessie.Naam} werd geregistreerd...";
                }
                catch
                {
                    TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet inschrijven...";

                }

            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Uitschrijven(int id, Gebruiker gebruiker)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (gebruiker != null && sessie != null)
            {
                try
                {
                    SessieGebruiker sessieGebruiker = sessie.GeefSessieGebruiker(gebruiker);
                    sessie.SchrijfGebruikerUit(sessieGebruiker, gebruiker);
                    _gebruikerRepository.SaveChanges();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je bent uitgeschreven voor {sessie.Naam} ...";
                }
                catch
                {
                    TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet uitschrijven ...";

                }

            }
            return RedirectToAction(nameof(Index));

        }

        #endregion

        #region Hulpmethodes
        private SelectList GetMaandSelectList(int maandId = 0)
        {
            var maanden = from Maand m in Enum.GetValues(typeof(Maand)) select new { ID = (int)m, Name = m.ToString() };
            return new SelectList(maanden, "ID", "Name", maandId);
        }
        #endregion

    }
}