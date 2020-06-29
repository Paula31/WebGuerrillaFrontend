using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGuerrillaFrontEnd.Models;

namespace WebGuerrillaFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        static String IPAdrress = "http://192.168.100.38:51438";
        static GuerrillaCompleted guerrilla;

        [HttpGet]
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

        [HttpPost]
        public ActionResult Registrarse(FormCollection formCollection)
        {
            ViewBag.Title = "Registrarse";

			try
			{
                Guerrilla guerrilla = new Guerrilla();
                guerrilla.GuerrillaName = formCollection["guerrillaName"];
                guerrilla.Faction = formCollection["faction"];
                guerrilla.Email = formCollection["email"];

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(IPAdrress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("/guerrilla/" + guerrilla.GuerrillaName, guerrilla).Result;

                return RedirectToAction("Index");
            }
			catch
			{
                return RedirectToActionPermanent("Registrarse");
            }

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

       [HttpGet]
        public async Task <ActionResult> Perfil()
        {
            ViewBag.Title = "Perfil";

            string name = Request.QueryString["GuerrillaName"];

			try
			{
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(IPAdrress+"/guerrilla/" + name);
                guerrilla = JsonConvert.DeserializeObject<GuerrillaCompleted>(json);
                ViewData["guerrilla"] = guerrilla;
                return View();

            }
            catch
			{
                return RedirectToActionPermanent("Index");
            }
        }

        [HttpPost]
        public ActionResult Perfil(FormCollection formCollection)
        {
            ViewBag.Title = "Perfil";


            try
            {
                Army army = new Army();
                Buildings buildings = new Buildings();

                army.Assault =Convert.ToInt32( formCollection["Army.Assault"]);
                army.Engineer = Convert.ToInt32(formCollection["Army.Engineer"]);
                army.Tank = Convert.ToInt32(formCollection["Army.Tank"]);
                buildings.Bunker = Convert.ToInt32(formCollection["Army.Assault"]);
                guerrilla.Army = army;
                guerrilla.Buildings = buildings;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(IPAdrress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PutAsJsonAsync("/guerrilla/" + guerrilla.Name + "/units", guerrilla).Result;

                return RedirectToAction("Perfil", new { GuerrillaName = guerrilla.Name });

            }
            catch
            {
                return RedirectToActionPermanent("Perfil", new { GuerrillaName = "Thor" });
            }
        }

    }
}
