using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahla.Server.Models
{
    public class AddHeaderMiddleware
    {
        private RequestDelegate _next;

        public AddHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization");
        }
    }
}
