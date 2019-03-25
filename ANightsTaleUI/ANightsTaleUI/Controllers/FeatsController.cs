using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class FeatsController : AServiceController
    {
        public FeatsController(HttpClient httpClient, IConfiguration configuration)
: base(httpClient, configuration)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static string url = "https://localhost:44369/api/Feat";
		// GET: Feats
		public async Task<ActionResult> Index()
        {
			var models = new List<Feats>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Feats> feats = JsonConvert.DeserializeObject<List<Feats>>(jsonString);
					return View(feats);
				}
			}

			return View(models);
		}

        // GET: Feats/Details/5
        public async Task<ActionResult> Details(int id)
        {
			var model = new Feats();
			using (var httpClient = new HttpClient())
			{

				var Response = await httpClient.GetAsync(url +"/"+ id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					Feats feats = JsonConvert.DeserializeObject<Feats>(jsonString);
					return View(feats);
				}
			}

			return View(model);
		}

        // GET: Feats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Feats collection)
        {
            try
            {
				using (var httpClient = new HttpClient())
				{
					var request = CreateRequestToService(HttpMethod.Post, url, collection);
					var Response = await httpClient.SendAsync(request);
				}

				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}