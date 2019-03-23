﻿using ANightsTaleUI.Controllers;
using ANightsTaleUI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ANightsTaleUI.Filters
{
    public class GetAccountDetailsFilter : IAsyncActionFilter
    {
        private readonly IConfiguration _configuration;

        public GetAccountDetailsFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // do something before the action executes
            // if the controller is an aservicecontroller, then
            // fetch the details, otherwise, do nothing.
            if (context.Controller is AServiceController controller)
            {
                HttpRequestMessage request = controller.CreateRequestToService(
                    HttpMethod.Get, _configuration["ServiceEndpoints:AccountDetails"]);

                HttpResponseMessage response = await controller.HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // setting "Result" in a filter short-circuits the rest
                    // of the MVC pipeline
                    // but i won't do that, i should just log it.
                }
                else
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    AccountDetails details = JsonConvert.DeserializeObject<AccountDetails>(jsonString);
                    controller.ViewData["accountDetails"] = details;
                    controller.Account = details;
                }
            }

            await next();
        }
    }
}
