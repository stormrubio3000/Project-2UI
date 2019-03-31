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

        // GET: Character
        public async Task<ActionResult> Index()
        {

            var account = ViewData["accountDetails"] as AccountDetails;



            var models = new List<Character>();
			using (var httpClient = new HttpClient())
			{
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                            Configuration["ServiceEndpoints:AccountCharacter"]);

                var Response = await httpClient.SendAsync(request);
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
            TempData["username"] = username;

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
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountCharacter"] + "/GetCharacter/" + id.ToString());
                var Response = await httpClient.SendAsync(request);
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
        public async Task<ActionResult> Create()
        {
            var model = new CreateCharacterViewModel();
            model.Character = new Character();
            model.Character.CampaignID = (int)TempData.Peek("campaignId");
            model.Character.Username = (string)TempData.Peek("username");

            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountRace"]);

                var Response = await httpClient.SendAsync(request);
                if (Response.IsSuccessStatusCode)
                {
                    var jsonString = await Response.Content.ReadAsStringAsync();
                    model.Races = JsonConvert.DeserializeObject<List<Race>>(jsonString);
                }

                HttpRequestMessage request2 = CreateRequestToService(HttpMethod.Get,
                            Configuration["ServiceEndpoints:AccountClass"]);

                var Response2 = await httpClient.SendAsync(request2);
                if (Response.IsSuccessStatusCode)
                {
                    var jsonString = await Response2.Content.ReadAsStringAsync();
                    model.Classes = JsonConvert.DeserializeObject<List<Class>>(jsonString);
                }
            }

                return View(model);
        }

        // POST: Character/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCharacterViewModel charModel)
        {
            try
            {
                TempData["classId"] = charModel.Character.ClassID;
                return RedirectToAction(nameof(Create2), "Character", charModel.Character);
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Create2Get
        public async Task<ActionResult> Create2(Character character)
        {
            var charModel = new CreateCharacterViewModel();
            charModel.Character = character;
            charModel.Skills = new List<Skill>();
            charModel.Classes = new List<Class>();
            charModel.Races = new List<Race>();

            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountCharacter"] + "/Class/" + character.ClassID.ToString());
                HttpRequestMessage request2 = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountClass"]);
                HttpRequestMessage request3 = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountRace"]);

                var Response = await httpClient.SendAsync(request);
                var Response1 = await httpClient.SendAsync(request2);
                var Response2 = await httpClient.SendAsync(request3);
                if (Response.IsSuccessStatusCode && Response1.IsSuccessStatusCode)

                if (Response.IsSuccessStatusCode)
                {
                    var jsonString = await Response.Content.ReadAsStringAsync();
                    var jsonString1 = await Response1.Content.ReadAsStringAsync();
                    var jsonString2 = await Response2.Content.ReadAsStringAsync();
                    charModel.Skills = JsonConvert.DeserializeObject<List<Skill>>(jsonString);
                    charModel.Classes = JsonConvert.DeserializeObject<List<Class>>(jsonString1);
                    charModel.Races = JsonConvert.DeserializeObject<List<Race>>(jsonString2);
                }


            }
            return View(charModel);
        }

        // POST: Character/Create2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create2(CreateCharacterViewModel charModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                        Configuration["ServiceEndpoints:AccountCharacter"] + "/Buffer", charModel.Character);

                    var Response = await httpClient.SendAsync(request);

                    //if (Response.IsSuccessStatusCode)
                    //{
                    //    var jsonString = await Response.Content.ReadAsStringAsync();
                    //    charModel.Character = JsonConvert.DeserializeObject<Character>(jsonString);
                    //}
                }
                return RedirectToAction(nameof(GetRolls), "Character", charModel.Character);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetRolls(Character character)
        {
            var model = new CreateCharacterViewModel();
            model.Character = character;
            return View(model);
        }

		public async Task<ActionResult> GetInventory(int id)
		{
			var models = new Inventorypass();
			using (var httpClient = new HttpClient())
			{
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountCharacter"] + "/Inventory/" + id.ToString());

                var Response = await httpClient.SendAsync(request);
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
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountItem"]);

                var Response = await httpClient.SendAsync(request);
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
                HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                        Configuration["ServiceEndpoints:AccountCharacter"]);

                using (var httpClient = new HttpClient())
				{
					var request2 = CreateRequestToService(HttpMethod.Post, request + "/Inventory" , collection);
					var Response = await httpClient.SendAsync(request2);
				}

				return RedirectToAction(nameof(GetInventory),new { id = selection.charID });
			}
			catch
			{
				return View(selection);
			}
		}





	}
}