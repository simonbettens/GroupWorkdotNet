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
        public SessieController(ISessieRepository sessieRepository)
        {
            this._sessieRepository = sessieRepository;
        }
        public ActionResult Index(int maandId=0) {
            if (maandId == 0)
            {
                maandId = DateTime.Now.Month;
            }
            IEnumerable<Sessie> sessies = _sessieRepository.GetByMaand(maandId).ToList();
            ViewData["bevatSessies"] = !sessies.Any();
            ViewData["Maanden"] = GetMaandSelectList(maandId);
            return View(sessies);
        }

        public ActionResult Details(int id) {
            Sessie sessie = _sessieRepository.GetById(id);
            var viewModel = new SessieDetailsViewModel(sessie);
            return View(viewModel);
        }
        private SelectList GetMaandSelectList(int maandId = 0)
        {
            var maanden = from Maand m in Enum.GetValues(typeof(Maand)) select new { ID = (int)m, Name = m.ToString() };
            return new SelectList(maanden,"ID", "Name", maandId);
        }

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult SchrijfIn(int sessieId, SessieDetailsViewModel viewModel) {
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
    }
}