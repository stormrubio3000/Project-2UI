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

		// GET: CharFeats/Details/5
		public async Task<ActionResult> Details(int id)
        {
			var models = new Featpass();
			using (var httpClient = new HttpClient())
			{
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
				$"{Configuration["ServiceEndpoints:CharFeats"]}/{id}");
				var Response = await httpClient.SendAsync(request);
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
        public async Task<ActionResult> Create(int id)
        {
			var models = new Featpass();
			using (var httpClient = new HttpClient())
			{
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
				$"{Configuration["ServiceEndpoints:Feat"]}");
				var Response = await httpClient.SendAsync(request);
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Feats> feats = JsonConvert.DeserializeObject<List<Feats>>(jsonString);
					var viewmodel = new Featpass { feats = feats, charID = id };
					return View(viewmodel);
				}


			}
			return View(models);
		}

        // POST: CharFeats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Featpass selection)
        {
			var collection = new CharFeats()
			{
				CharacterId = selection.charID,
				FeatId = selection.feat.FeatID
			};
			try
			{
				using (var httpClient = new HttpClient())
				{
					var request = CreateRequestToService(HttpMethod.Post, $"{Configuration["ServiceEndpoints:CharFeats"]}", collection);
					var Response = await httpClient.SendAsync(request);
				}

				return RedirectToAction(nameof(Details), new { id = selection.charID });
			}
			catch
			{
				return View(selection);
			}
		}
    }
}