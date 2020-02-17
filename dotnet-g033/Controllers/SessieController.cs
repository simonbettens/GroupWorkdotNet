using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g033.Controllers
{
    public partial class SessieController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}