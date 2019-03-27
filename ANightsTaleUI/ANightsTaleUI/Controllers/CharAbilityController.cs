using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using ANightsTaleUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class CharAbilityController : AServiceController
    {
		public CharAbilityController(HttpClient httpClient, IConfiguration configuration)
: base(httpClient, configuration)
		{
		}
		static string url = "https://localhost:44369/api/CharAbility";
		// GET: CharAbility/Details/5
		public async Task<ActionResult> GetAbilities(int id)
        {
			var models = new Abilitypass();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url + "/" + id.ToString());
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
        public async Task<ActionResult> Create(int id)
        {
			var models = new AbilityChar();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync("https://localhost:44369/api/Ability");
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Abilities> abilities = JsonConvert.DeserializeObject<List<Abilities>>(jsonString);
					var viewmodel = new AbilityChar { abilities = abilities, charID = id };
					return View(viewmodel);
				}


			}
			return View(models);
		}

        // POST: CharAbility/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AbilityChar selection)
        {
			var collection = new CharAbilities()
			{
				CharacterId = selection.charID,
				AbilityId = selection.ability.AbilityID,
				Mods = selection.mod
			};
			try
			{
				using (var httpClient = new HttpClient())
				{
					var request = CreateRequestToService(HttpMethod.Post, url + "/", collection);
					var Response = await httpClient.SendAsync(request);
				}

				return RedirectToAction(nameof(GetAbilities), new {id = selection.charID});
            }
            catch
            {
                return View(selection);
            }
        }
    }
}