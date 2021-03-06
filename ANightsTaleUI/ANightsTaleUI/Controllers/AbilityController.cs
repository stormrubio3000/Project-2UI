﻿using System;
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
    public class AbilityController : AServiceController
    {
        public AbilityController(HttpClient httpClient, IConfiguration configuration)
: base(httpClient, configuration)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		// GET: Ability
		public async Task<ActionResult> Index()
        {
			var models = new List<Abilities>();
			using (var httpClient = new HttpClient())
			{
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
				$"{Configuration["ServiceEndpoints:Ability"]}");
				var Response = await httpClient.SendAsync(request);
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
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
				$"{Configuration["ServiceEndpoints:Ability"]}/{id}");
				var Response = await httpClient.SendAsync(request);
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
        public async Task<ActionResult> Create(Abilities collection)
        {
			try
			{
				using (var httpClient = new HttpClient())
				{
					var request = CreateRequestToService(HttpMethod.Post, $"{Configuration["ServiceEndpoints:Ability"]}", collection);
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