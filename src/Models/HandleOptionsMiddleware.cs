using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahla.Server.Models
{
    public class HandleOptionsMiddleware
    {
        private RequestDelegate _next;

        public HandleOptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = 204;
                return context.Response.WriteAsync("This response allow browser to send requests.");
            }
            return _next.Invoke(context);
        }
    }
}
