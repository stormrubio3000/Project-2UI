using System;
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
        static string urlRace = "https://localhost:44369/api/Race";
        static string urlClass = "https://localhost:44369/api/Class";
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
            TempData["campaignId"] = id;

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

				var Response = await httpClient.GetAsync(url+"/GetCharacter/" + id.ToString());
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
        public async Task<ActionResult> Create(CreateCharacterViewModel charModel)
        {
            try
            {
                charModel.Character.CampaignID = (int)TempData["campaignId"];

                using (var httpClient = new HttpClient())
                {
                    var Response1 = await httpClient.GetAsync(urlRace);
                    if (Response1.IsSuccessStatusCode)
                    {
                        var jsonString = await Response1.Content.ReadAsStringAsync();
                        charModel.Races = JsonConvert.DeserializeObject<List<Race>>(jsonString);
                    }

                    var Response2 = await httpClient.GetAsync(urlClass);
                    if (Response2.IsSuccessStatusCode)
                    {
                        var jsonString = await Response2.Content.ReadAsStringAsync();
                        charModel.Classes = JsonConvert.DeserializeObject<List<Class>>(jsonString);
                    }

                    return RedirectToAction(nameof(Create2), "Character", charModel);
                }  
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Create
        public ActionResult Create2(CreateCharacterViewModel charModel)
        {

            return View();
        }

        // POST: Character/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2Post(CreateCharacterViewModel charModel)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

		public async Task<ActionResult> GetInventory(int id)
		{
			var models = new Inventorypass();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url+ "/Inventory/" + id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
					var viewmodel = new Inventorypass() { items = items, charID = id };
					return View(viewmodel);
				}
			}

			return View(models);
		}

		public async Task<ActionResult> CreateInventory(int id)
		{
			var models = new ItemInv();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync("https://localhost:44369/api/Item");
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
					var viewmodel = new ItemInv { items = items, charID=id };
					return View(viewmodel);
				}


			}
			return View(models);
		}

		// POST: Character/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateInventory(ItemInv selection)
		{
			var collection = new Inventory() { CharacterID = selection.charID,
				ItemID = selection.item.ItemID, Quantity = selection.quantity, ToggleE = false };
			try
			{
				using (var httpClient = new HttpClient())
				{
					var request = CreateRequestToService(HttpMethod.Post, url + "/Inventory" , collection);
					var Response = await httpClient.SendAsync(request);
				}

				return RedirectToAction(nameof(GetInventory),new { id = selection.charID });
			}
			catch
			{
				return View();
			}
		}





	}
}