using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class AbilityController : Controller
    {
		static string url = "https://localhost:44369/api/Ability";
		// GET: Ability
		public async Task<ActionResult> Index()
        {
			var models = new List<Abilities>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Abilities> abilities = JsonConvert.DeserializeObject<List<Abilities>>(jsonString);
					return View(abilities);
				}
			}

			return View(models);
		}

        // GET: Ability/Details/5
        public async Task<ActionResult> Details(int id)
        {
			var model = new Abilities();
			using (var httpClient = new HttpClient())
			{

				var Response = await httpClient.GetAsync(url +"/" + (id).ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					Abilities abilities = JsonConvert.DeserializeObject<Abilities>(jsonString);
					return View(abilities);
				}
			}

			return View(model);
		}

        // GET: Ability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ability/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}