using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleUI.Controllers
{
    public class AbilityController : Controller
    {
		static string url = "https://localhost:44369/api/Ability";
		// GET: Ability
		public ActionResult Index()
        {
            return View();
        }

        // GET: Ability/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ability/Create
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
    }
}