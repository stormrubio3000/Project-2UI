using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleUI.Controllers
{
    public class CampaignController : Controller
    {

		static string url = "https://localhost:44369/api/Campaign";
		// GET: Campaign
		public ActionResult Index()
        {
            return View();
        }

        // GET: Campaign/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Campaign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaign/Create
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