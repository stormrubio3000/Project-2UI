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
using PagedList;

namespace ANightsTaleUI.Controllers
{
    public class ItemController : AServiceController
    {
        public ItemController(HttpClient httpClient, IConfiguration configuration)
: base(httpClient, configuration)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static string url = "https://localhost:44369/api/Item";
		// GET: Item
		public async Task<ActionResult> Index(int? page)
        {
			var models = new List<Item>();
			using (var httpClient = new HttpClient())
			{
				var Response = await httpClient.GetAsync(url);
				if(Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
					return View(items);
				}
			}

            int pageSize = 3;
            int pageNumber = (page ?? 1);
           //return View(models.ToPagedList(pageNumber, pageSize));

            return View(models);
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(int id)
        {

			var model = new Item();
			using (var httpClient = new HttpClient())
			{

				var Response = await httpClient.GetAsync(url+"/"+id.ToString());
				if (Response.IsSuccessStatusCode)
				{
					var jsonString = await Response.Content.ReadAsStringAsync();
					Item item = JsonConvert.DeserializeObject<Item>(jsonString);
					return View(item);
				}
			}

			return View(model);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Item collection)
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