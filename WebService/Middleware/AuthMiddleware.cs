using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebService.Middleware
{
    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }

    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DataService _dataService;
        //henter dataservice
        public AuthMiddleware(RequestDelegate next, DataService dataService)
        {
            _next = next;
            _dataService = dataService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Program.CurrentUser = null;

            //Henter header string og tjekker om navnet er i dummy dataen
            var auth = context.Request.Headers["Authorization"].ToString();
            // auth = "testing";
            Console.WriteLine("!");
            if (!string.IsNullOrEmpty(auth))
            {

                Program.CurrentUser = _dataService.GetUser(auth.ToString());

                Console.WriteLine("Finding users");
            }
            await _next(context);
        }
    }
}
