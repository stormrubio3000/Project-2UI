using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ANightsTaleUI.Controllers
{
    public class AccountController : AServiceController
    {

        public AccountController(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration)
        {
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
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

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Users register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                Configuration["ServiceEndpoints:AccountRegister"], register);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            // login success
            return RedirectToAction("Index", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            // the header value contains both the name and value of the cookie itself
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values) &&
                values.FirstOrDefault(x => x.StartsWith(Configuration["ServiceCookieName"])) is string headerValue)
            {
                // copy that cookie to the response we will send to the client
                Response.Headers.Add("Set-Cookie", headerValue);
                return true;
            }
            return false;
        }
    }
}