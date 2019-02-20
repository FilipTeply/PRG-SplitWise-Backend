using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SplitWise.Model;
using SplitWise.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class SplitWiseMiddleware
    {
        private readonly RequestDelegate _next;


        public SplitWiseMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, UserServices userServices)
        {
            if (!context.Request.Path.Value.Contains("/login"))
            {
                string estoken = context.Request.Headers["estoken"];

                if (string.IsNullOrEmpty(estoken) || !userServices.TokenExists(estoken))
                {
                    ErrorResponseBody responseBody = new ErrorResponseBody("Unauthorized request!");

                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody));
                    return;
                }
                else
                {
                    User currentUser = userServices.FindUserByUserToken(estoken);
                    context.Items["user"] = currentUser;
                }
            }
            await _next(context);
        }
    }
}
