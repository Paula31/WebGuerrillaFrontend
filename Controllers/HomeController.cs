using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGuerrillaFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Registrarse()
        {
            ViewBag.Title = "Registrarse";

            return View();
        }

        public ActionResult Ranking()
        {
            ViewBag.Title = "Ranking";

            return View();
        }


        public ActionResult Batalla()
        {
            ViewBag.Title = "Batalla";

            return View();
        }

        public ActionResult Ajustes()
        {
            ViewBag.Title = "Ajustes";

            return View();
        }
    }
}
