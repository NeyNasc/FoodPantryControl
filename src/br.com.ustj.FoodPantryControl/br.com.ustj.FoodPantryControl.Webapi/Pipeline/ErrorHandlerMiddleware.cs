﻿using br.com.ustj.FoodPantryControl.Domain;
using br.com.ustj.FoodPantryControl.Infrastructure;
using br.com.ustj.FoodPantryControl.Webapi.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace br.com.ustj.FoodPantryControl.Webapi.Pipeline
{
    public class ErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment env;
        private readonly IStringLocalizer<ReturnMessages> localization;

        public ErrorHandlerMiddleware(IWebHostEnvironment env, IStringLocalizer<ReturnMessages> localization)
        {
            this.env = env;
            this.localization = localization;
        }

        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (ex == null)
            {
                return;
            }

            var model = new ProblemDetails
            {
                Detail = ex.Message
            };

            if (ex is ApiException apiException)
            {
                context.Response.StatusCode = apiException.HttpStatusCode;
                model.Title = apiException.Title;
            }
            else if (ex is ApplicationException || ex is DomainException || ex is InfrastructureException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = $"{localization["ServerError"]}: {ex.Message}";
            }
            else if (ex is ArgumentOutOfRangeException)
            {
                context.Response.StatusCode = 404;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }
            else if (ex is NullReferenceException || ex is ArgumentException)
            {
                context.Response.StatusCode = 400;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = localization["ServerError"];
            }

            if (env.IsDevelopment())
            {
                model.Detail += $"{ex.GetType().ToString()}: {ex.Message}: {ex.StackTrace}";
            }

            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
