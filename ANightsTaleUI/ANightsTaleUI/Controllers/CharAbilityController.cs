using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using ANightsTaleUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class CharAbilityController : Controller
    {
		static string url = "https://localhost:44369/api/CharAbility";
		// GET: CharAbility/Details/5
		public async Task<ActionResult> GetAbilities(int id)
        {
			var models = new Abilitypass();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url + "/Inventory/" + id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Abilities> abilities = JsonConvert.DeserializeObject<List<Abilities>>(jsonString);
					var viewmodel = new Abilitypass() { Abilities = abilities, charID = id };
					return View(viewmodel);
				}
			}

			return View(models);
		}

        // GET: CharAbility/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharAbility/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(GetAbilities));
            }
            catch
            {
                return View();
            }
        }
    }
}