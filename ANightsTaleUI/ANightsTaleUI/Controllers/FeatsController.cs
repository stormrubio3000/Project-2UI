using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class FeatsController : Controller
    {
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

        // GET: Feats/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Feats/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feats/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}