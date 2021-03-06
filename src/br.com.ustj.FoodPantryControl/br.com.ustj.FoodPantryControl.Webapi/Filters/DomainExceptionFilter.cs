﻿using br.com.ustj.FoodPantryControl.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace br.com.ustj.FoodPantryControl.Webapi.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            DomainException domainException = context.Exception as DomainException;
            if (domainException != null)
            {
                string json = JsonConvert.SerializeObject(domainException.Message);

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
