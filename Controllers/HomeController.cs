using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
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

        [HttpGet]
        public async Task<ActionResult> Batalla()
        {
            ViewBag.Title = "Batalla";

			try
			{
                string guerrillaEnemy = Request.QueryString["guerrillaEnemy"];
                string guerrillaSrc = Request.QueryString["guerrillaSrc"];

                string cadena = guerrillaEnemy+"?guerrillaSrc="+guerrillaSrc;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(IPAdrress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("/guerrilla/attack/"+cadena, null).Result;
                var json = await response.Content.ReadAsStringAsync();
				var guerrillas = JsonConvert.DeserializeObject<Guerrillas>(json);
				ViewData["guerrillas"] = guerrillas;

				return View();

            }
            catch
			{
                return RedirectToActionPermanent("Ranking");
			}
           

        }
        [HttpGet]
        public ActionResult Ajustes()
        {
            ViewBag.Title = "Ajustes";
            ViewData["IPAdrress"] = IPAdrress;

            return View();
        }

        [HttpPost]
        public ActionResult Ajustes(FormCollection formCollection)
        {
            ViewBag.Title = "Ajustes";

            IPAdrress = formCollection["txtIP"];
            ViewData["IPAdrress"] = IPAdrress;
            return RedirectToActionPermanent("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Ranking()
        {
            ViewBag.Title = "Ranking";

            string cadena = "";

            String name= Request.QueryString["GuerrillaName"];
            String faction = Request.QueryString["Faction"];
            if (Request.QueryString["GuerrillaName"] == null && Request.QueryString["Faction"] == null)
            {
                cadena = "";
			}else
            if (Request.QueryString["GuerrillaName"] == "" && Request.QueryString["Faction"] == "")
            {
                cadena = "";
            }else
            if (name == "")
			{
                cadena = "?faction="+faction.Trim();
			}else
			if (faction == "")
			{
                cadena = "?name="+name.Trim();
			}else
			if (name != "" && faction != "")
			{
                cadena = "?faction=" + faction.Trim() + "&name=" + name.Trim();
			}


            var httpClient = new HttpClient();
			var json = await httpClient.GetStringAsync(IPAdrress + "/guerrilla"+ cadena);
			var guerrillas = JsonConvert.DeserializeObject<List<GuerrillaAll>>(json);

            ViewData["guerrillas"] = guerrillas;
            ViewData["guerrillaActual"] = guerrilla;


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
