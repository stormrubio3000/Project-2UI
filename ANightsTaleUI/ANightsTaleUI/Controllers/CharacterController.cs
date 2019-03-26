﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class CharacterController : AServiceController
    {
        public CharacterController(HttpClient httpClient, IConfiguration configuration)
        : base(httpClient, configuration)
        {
        }

        static string url = "https://localhost:44369/api/Character";
		// GET: Character
		public async Task<ActionResult> Index()
        {

            var account = ViewData["accountDetails"] as AccountDetails;



            var models = new List<Character>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Character> character = JsonConvert.DeserializeObject<List<Character>>(jsonString);
					return View(character);
				}
			}

			return View(models);
		}

        public async Task<ActionResult> CampaignList(int campId)
        {
            var account = ViewData["accountDetails"] as AccountDetails;

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                Configuration["ServiceEndpoints:Campaign"]);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                return View("Error", new ErrorViewModel());
            }

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View("Error", new ErrorViewModel());
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            List<Campaign> campaigns = JsonConvert.DeserializeObject<List<Campaign>>(jsonString);

            return View(campaigns);
        }

        public async Task<ActionResult> CharCampUsr(int id, string username)
        {
            HttpRequestMessage request1 = CreateRequestToService(HttpMethod.Get,
                Configuration["ServiceEndpoints:AccountCharacter"] + "/" + "CharCampUsr" + "/" + id + "?username=" + username);


            HttpResponseMessage response1;
            try
            {
                response1 = await HttpClient.SendAsync(request1);
            }
            catch (HttpRequestException)
            {
                return View("Error", new ErrorViewModel());
            }

            if (!response1.IsSuccessStatusCode)
            {
                if (response1.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View("Error", new ErrorViewModel());
            }
            var jsonString1 = await response1.Content.ReadAsStringAsync();
            
            List<Character> charactersUsrCamp = JsonConvert.DeserializeObject<List<Character>>(jsonString1);


            HttpRequestMessage request2 = CreateRequestToService(HttpMethod.Get,
                Configuration["ServiceEndpoints:AccountCharacter"] + "/" + id);


            HttpResponseMessage response2;
            try
            {
                response2 = await HttpClient.SendAsync(request2);
            }
            catch (HttpRequestException)
            {
                return View("Error", new ErrorViewModel());
            }

            if (!response2.IsSuccessStatusCode)
            {
                if (response2.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View("Error", new ErrorViewModel());
            }
            var jsonString2 = await response2.Content.ReadAsStringAsync();

            List<Character> charactersCamp = JsonConvert.DeserializeObject<List<Character>>(jsonString2);

            CharactersLists charLists = new CharactersLists
            {
                campCharacters = charactersCamp,
                usrCampCharacters = charactersUsrCamp
            };

            return View(charLists);
        }

        // GET: Character/Details/5
        public async Task<ActionResult> Details(int id)
        {
			var model = new Character();
			using (var httpClient = new HttpClient())
			{

				var Response = await httpClient.GetAsync(url + "/" + id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					Character character = JsonConvert.DeserializeObject<Character>(jsonString);
					return View(character);
				}
			}

			return View(model);
		}

        // GET: Character/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
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

		public async Task<ActionResult> GetInventory(int id)
		{
			var models = new List<Item>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url+ "/GetInv/" + id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
					return View(items);
				}
			}

			return View(models);
		}
    }
}