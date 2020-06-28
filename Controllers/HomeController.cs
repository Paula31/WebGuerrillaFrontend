using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGuerrillaFrontEnd.Models;

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



            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync("http://192.168.100.38:51438/guerrilla");
            //var guerrillas = JsonConvert.DeserializeObject<List<Guerrilla>>(json);

            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(FormCollection formCollection)
        {
            ViewBag.Title = "Registrarse";

            Guerrilla guerrilla = new Guerrilla();
            guerrilla.GuerrillaName = formCollection["guerrillaName"];
            guerrilla.Faction = formCollection["faction"];
            guerrilla.Email = formCollection["email"];
            var json = JsonConvert.SerializeObject(guerrilla);


            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync("http://192.168.100.38:51438/guerrilla");
            //var guerrillas = JsonConvert.DeserializeObject<List<Guerrilla>>(json);

            return RedirectToActionPermanent("Registrarse");
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

        public ActionResult Ranking()
        {
            ViewBag.Title = "Ranking";

            return View();
        }

       
            public ActionResult Perfil()
        {
            ViewBag.Title = "Perfil";

            return View();
        }
    }
}
