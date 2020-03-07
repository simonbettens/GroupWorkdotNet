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
    /// <summary>
    /// 
    /// </summary>
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
        /// <summary>
        /// Geeft een view terug waarop alle sessies die zich in de geselecteerde maand bevinden weergeven worden.
        /// Als er geen maand geselecteerd is wordt de huidige maand gekozen als parameter.
        /// </summary>
        /// <param name="gebruiker">De ingelogde gebruiker</param>
        /// <param name="maandId">De geselecteerde maand</param>
        /// <returns>Een view met alle sessies van de geselecteerde maand</returns>
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


        /// <summary>
        /// Geeft een view terug met alle details van een geselecteerde sessie.
        /// Er wordt ook meegegeven of de gebruiker al ingeschreven of aanwezig staat voor de gekozen sessie.
        /// </summary>
        /// <param name="id">Het Id van de geselecteerde sessie</param>
        /// <param name="gebruiker">de ingelogde gebruiker</param>
        /// <returns>een view met alle info van de gekozen sessie</returns>
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
            TempData["error"] = "Er is iets mis gegaan, we konden de sessie niet ophalen.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Inschrijven & Uitschrijven & Aanwezig Stellen
        /// <summary>
        /// De gebruiker inschrijven in de geselecteerde sessie.
        /// Er wordt gecontroleerd of de gebruiker ingelogd is en of de sessie bestaat.
        /// </summary>
        /// <param name="id">de id van de geselecteerde sessie</param>
        /// <param name="gebruiker">de ingelogde gebruiker</param>
        /// <returns>een detailview van de gekozen sessie met een melding of de inschrijving geslaagd is</returns>
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
                    TempData["error"] = "Er is iets mis gegaan, we konden je niet inschrijven.";

                }

            }
            return RedirectToAction("Details", new { id = id });

        }

        /// <summary>
        /// De gebruiker wordt uigeschreven uit de geselecteerde sessie.
        /// Er wordt gecontroleerd of de gebruiker ingeschreven is en of de sessie en gebruiker bestaan.
        /// De gebruiker kan niet uitschrijven als de sessie reeds afgelopen is.
        /// </summary>
        /// <param name="id">De id van de geselecteerde sessie</param>
        /// <param name="gebruiker">de ingelogde gebruiker</param>
        /// <returns>Een detailview van de gekozen sessie met een melding of de uitschrijving geslaagd is</returns>
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Uitschrijven(int id, Gebruiker gebruiker) {
            try {
                Sessie sessie = _sessieRepository.GetById(id);
                if (gebruiker != null && sessie != null) {
                    if (sessie.EindDatum > DateTime.Now) {
                        SessieGebruiker sessieGebruiker = sessie.GeefSessieGebruiker(gebruiker);
                        sessie.SchrijfGebruikerUit(sessieGebruiker, gebruiker);
                        _gebruikerRepository.SaveChanges();
                        _sessieRepository.SaveChanges();
                        TempData["message"] = $"Je bent uitgeschreven voor {sessie.Naam}.";
                    }
                    else {
                        TempData["error"] = "De sessie is reeds afgelopen. Uitschrijven is niet meer mogelijk.";
                    }
                }
                else {
                    TempData["error"] = "Er is iets mis gegaan, we konden je niet uitschrijven.";
                }
            }
            catch {
                TempData["error"] = "Er is iets mis gegaan, we konden je niet uitschrijven.";
            }
            return RedirectToAction("Details", new { id = id });

        }

        /// <summary>
        /// De gebruiker wordt aanwezig gesteld op een sessie waar hij ingeschreven is.
        /// Er wordt gecontroleerd of de sessie open staat en of de gebruiker ingeschreven is. 
        /// </summary>
        /// <param name="id">De id van de geselecteerde sessie</param>
        /// <param name="gebruiker">de ingelogde gebruiker</param>
        /// <returns>Een detailview van de gekozen sessie met een melding of de aanmelding geslaagd is</returns>
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
                        TempData["error"] = "Er is iets mis gegaan, we konden je niet aanmelden.";
                    }
                }
                else {
                    TempData["error"] = "Deze sessie staat momenteel niet open.";
                }
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