using dotnet_g033.Filters;
using dotnet_g033.Models.Domain;
using dotnet_g033.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_g033.Controllers {

    [Authorize]
    public class SessieController : Controller {

        #region Repositories

        private readonly ISessieRepository _sessieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        #endregion

        #region Constructor
        public SessieController(ISessieRepository sessieRepository, IGebruikerRepository gebruikerRepository) {
            this._sessieRepository = sessieRepository;
            this._gebruikerRepository = gebruikerRepository;
        }

        #endregion

        #region Index & Details

        [ServiceFilter(typeof(GebruikerFilter))]

        public ActionResult Index(Gebruiker gebruiker, int maandId = 0) {
            if (maandId == 0) {
                maandId = DateTime.Now.Month;
            }
            HashSet<Sessie> hashSessies = _sessieRepository.GetByMaand(maandId).Where(s => s.Gesloten != true).ToHashSet();
            ViewData["bevatSessies"] = !hashSessies.Any();
            ViewData["Ingelogd"] = true;
            IEnumerable<Sessie> sessies = new List<Sessie>(hashSessies);
            ViewData["Maanden"] = GetMaandSelectList(maandId);
            SessieIndexViewmodel viewmodel = new SessieIndexViewmodel(gebruiker, sessies);
            return View(viewmodel);
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public ActionResult Details(int id, Gebruiker gebruiker) {
            Sessie sessie = _sessieRepository.GetById(id);
            if (sessie != null) {
                bool ingeschreven = sessie.GebruikerIsIngeschreven(gebruiker);
                ViewData["IsIngeschreven"] = ingeschreven;
                if (ingeschreven) {
                    ViewData["IsAanwezig"] = sessie.GeefSessieGebruiker(gebruiker).Aanwezig;
                }
                else {
                    ViewData["IsAanwezig"] = false;
                }
                var viewModel = new SessieDetailsViewModel(sessie);
                return View(viewModel);
            }
            TempData["error"] = "Sorry, er is iets mis gegaan, we konden de sessie niet ophalen...";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Inschrijven & Uitschrijven & Aanwezig Stellen

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult InSchrijven(int id, Gebruiker gebruiker) {
            Sessie sessie = _sessieRepository.GetById(id);
            if (gebruiker != null && sessie != null) {
                try {
                    SessieGebruiker sessieGebruiker = new SessieGebruiker(sessie, gebruiker);
                    sessie.SchrijfGebruikerIn(sessieGebruiker, gebruiker);
                    _gebruikerRepository.SaveChanges();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je inschrijving voor {sessie.Naam} werd geregistreerd.";
                }
                catch {
                    TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet inschrijven.";

                }

            }
            return RedirectToAction("Details", new { id = id });

        }
        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Uitschrijven(int id, Gebruiker gebruiker) {
            try {
                Sessie sessie = _sessieRepository.GetById(id);
                if (gebruiker != null && sessie != null) {

                    SessieGebruiker sessieGebruiker = sessie.GeefSessieGebruiker(gebruiker);
                    sessie.SchrijfGebruikerUit(sessieGebruiker, gebruiker);
                    _gebruikerRepository.SaveChanges();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je bent uitgeschreven voor {sessie.Naam}.";
                }
                else {
                    throw new Exception();
                }
            }
            catch {
                TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet uitschrijven.";

            }
            return RedirectToAction("Details", new { id = id });

        }

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult AanwezigStellen(int id, Gebruiker gebruiker) {
            Sessie sessie = _sessieRepository.GetById(id);
            if (gebruiker != null && sessie != null) {
                if (sessie.GebruikerIsIngeschreven(gebruiker) && sessie.StaatOpen) {
                    try {
                        sessie.StelGebruikerAanwezig(sessie.GeefSessieGebruiker(gebruiker));
                        _gebruikerRepository.SaveChanges();
                        _sessieRepository.SaveChanges();
                        TempData["message"] = $"Je staat aanwezig voor {sessie.Naam}.";
                    }
                    catch {
                        TempData["error"] = "Sorry, er is iets mis gegaan, we konden je niet aanmelden.";
                    }
                }
            }

            else {
                TempData["error"] = "Deze sessie staat momenteel nog niet open.";
            }
            return RedirectToAction("Details", new { id = id });
        }

        #endregion

        #region Open Zetten
        [ServiceFilter(typeof(GebruikerFilter))]
        public ActionResult OpenzettenIndex(Gebruiker gebruiker, int maandId = 0) {
            if (maandId == 0) {
                maandId = DateTime.Now.Month;
            }
            HashSet<Sessie> hashSessies;
            if ((int)gebruiker.Type == 3)
                hashSessies = _sessieRepository.GetSessieHoofdVerantwoordelijkeNogTeOpenen(gebruiker, maandId).ToHashSet();
            else
                hashSessies = _sessieRepository.GetSessieVerantwoordelijkeNogTeOpenen(gebruiker, maandId).ToHashSet();
            IEnumerable<Sessie> sessies = new List<Sessie>(hashSessies);
            ViewData["BevatSessies"] = sessies.Any();
            ViewData["Maanden"] = GetMaandSelectList(maandId);
            SessieIndexViewmodel viewmodel = new SessieIndexViewmodel(gebruiker, sessies);
            return View(viewmodel);
        }

        public ActionResult VeranderStaatOpen(int id) {
            Sessie sessie = _sessieRepository.GetById(id);
            HashSet<Sessie> hashSessies = _sessieRepository.GetAll().ToHashSet();
            IEnumerable<Sessie> sessies = new List<Sessie>(hashSessies);
            IEnumerable<Sessie> sessiesOpen = new List<Sessie>(sessies.Where(s => s.StaatOpen == true));
            if (sessie != null) {
                if (sessie.StaatOpen == true) {
                    sessie.Sluit();
                    TempData["message"] = $"{sessie.Naam} is gesloten";
                }
                else {
                    if (sessiesOpen.Count() > 0) {
                        TempData["error"] = $"Er staat al een sessie open van {sessiesOpen.ToList().First().Verantwoordelijke.Voornaam} {sessiesOpen.ToList().First().Verantwoordelijke.Achternaam}!";
                    }
                    else {
                        sessie.ZetOpen();
                        TempData["message"] = $"{sessie.Naam} staat nu open";
                    }
                }
                _sessieRepository.SaveChanges();
            }
            return RedirectToAction("OpenzettenIndex");
        }
        #endregion


        #region Hulpmethodes
        private SelectList GetMaandSelectList(int maandId = 0) {
            var maanden = from Maand m in Enum.GetValues(typeof(Maand)) select new { ID = (int)m, Name = m.ToString() };
            return new SelectList(maanden, "ID", "Name", maandId);
        }
        #endregion
    }
}