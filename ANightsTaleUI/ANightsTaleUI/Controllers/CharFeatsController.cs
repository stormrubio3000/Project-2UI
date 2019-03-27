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
    public class CharFeatsController : AServiceController
	{
		public CharFeatsController(HttpClient httpClient, IConfiguration configuration)
		: base(httpClient, configuration)
		{
		}


		static string url = "https://localhost:44369/api/CharFeats";
		// GET: CharFeats/Details/5
		public async Task<ActionResult> Details(int id)
        {
			var models = new Featpass();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url + "/" + id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Feats> feats = JsonConvert.DeserializeObject<List<Feats>>(jsonString);
					var viewmodel = new Featpass() { feats = feats, charID = id };
					return View(viewmodel);
				}
			}

			return View(models);
		}

        // GET: CharFeats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharFeats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }
    }
}