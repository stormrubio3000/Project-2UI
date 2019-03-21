using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ANightsTaleUI.Controllers
{
    public class LoginController : Controller
    {
        static string url = "https://localhost:44369/api/Users";

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
            try
            {
                if (ModelState.IsValid)
                {
                    using (var httpClient = new HttpClient())
                    {
                        await AddUserAsync(url, httpClient, user);
                    }

                    RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        static async Task AddUserAsync(string url, HttpClient httpClient, Users user)
        {
            var newUser = new Users {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Permission = user.Permission
            };

            var json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            // throw an exception if status code indicates failure
            response.EnsureSuccessStatusCode();
        }
    }
}