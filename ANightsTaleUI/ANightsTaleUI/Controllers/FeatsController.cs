using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleUI.Controllers
{
    public class FeatsController : Controller
    {
		static string url = "https://localhost:44369/api/Feats";
		// GET: Feats
		public ActionResult Index()
        {
			var models = new List<Feats>();
			//ToDo: talk to the API
            return View(models);
        }

        // GET: Feats/Details/5
        public ActionResult Details(int id)
        {
            return View();
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