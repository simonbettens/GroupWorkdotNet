using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g033.Models.Domain;
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
            return View();
        }
        private SelectList GetMaandSelectList(int maandId = 0)
        {
            var maanden = from Maand m in Enum.GetValues(typeof(Maand)) select new { ID = (int)m, Name = m.ToString() };
            return new SelectList(maanden,"ID", "Name", maandId);
        }
    }
}