using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class CampaignController : AServiceController
    {
        public CampaignController(HttpClient httpClient, IConfiguration configuration)
    : base(httpClient, configuration)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static string url = "https://localhost:44369/api/Campaign";
		// GET: Campaign
		public async Task<ActionResult> Index()
        {
			var models = new List<Campaign>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Campaign> campaign = JsonConvert.DeserializeObject<List<Campaign>>(jsonString);
					return View(campaign);
				}
			}

			return View(models);
		}

        // GET: Campaign/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TempData["campaignId"] = id;
            var model = new Campaign();
			using (var httpClient = new HttpClient())
			{

				var Response = await httpClient.GetAsync(url +"/"+ id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					Campaign campaign = JsonConvert.DeserializeObject<Campaign>(jsonString);
					return View(campaign);
				}
			}

			return View(model);
		}

        // GET: Campaign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaign/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Campaign collection)
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

        public async Task<ActionResult> DetailsAsync(int id)
        {
            

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                Configuration["ServiceEndpoints:AccountCampaign"] + "/" + id);

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

            List<Campaign> charactersUsrCamp = JsonConvert.DeserializeObject<List<Campaign>>(jsonString);

            return View();
        }

        public ActionResult CreateInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateInfo(Info info)
        {
            info.CampaignID = (int)TempData["campaignId"];

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                Configuration["ServiceEndpoints:AccountCampaign"] + "/" + "CreateInfo", info);

            HttpResponseMessage response;

            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(info);
            }

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Unexpected server error");
                return View(info);
            }

            return RedirectToAction("Index", "Campaign");
        }
    }
}