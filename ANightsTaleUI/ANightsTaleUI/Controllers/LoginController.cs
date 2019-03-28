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

        // GET: /Account/Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                Configuration["ServiceEndpoints:AccountLogin"], login);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(login);
            }

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // login failed because bad credentials
                    ModelState.AddModelError("", "Login or password incorrect.");
                }
                else
                {
                    ModelState.AddModelError("", "Unexpected server error");
                }
                return View("Index");
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(login);
            }

            // login success
            return RedirectToAction("Index", "Campaign");
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                Configuration["ServiceEndpoints:AccountLogout"]);

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
                return View("Error", new ErrorViewModel());
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                return View("Error", new ErrorViewModel());
            }

            // logout success
            return RedirectToAction("Index", "Login");
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
                ModelState.AddModelError("", "Passwords must be at least 12 characters, one non alphanumeric character, one digit ('0'-'9').");
                return View(user);
            }

            return RedirectToAction("Index", "Campaign");
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

        // GET: Character/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get,
                $"{Configuration["ServiceEndpoints:Users"]}/{id}");

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
            Login user = JsonConvert.DeserializeObject<Login>(jsonString);

            return View(user);
        }
    }
}