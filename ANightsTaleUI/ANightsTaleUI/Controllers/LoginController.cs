using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class LoginController : AServiceController
    {
        public LoginController(HttpClient httpClient, IConfiguration configuration)
                : base(httpClient, configuration)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUpAsync()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUpAsync(Users user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }

                HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                    Configuration["ServiceEndpoints:Users"], user);

                HttpResponseMessage response;

            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(user);
            }

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Unexpected server error");
                return View(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}