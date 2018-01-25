using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kahla.Server.Attributes
{
    public class AllowMethodHeader : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization");
            if(context.HttpContext.Request.Method.ToLower().Trim()=="options")
            {
                context.Result = new NoContentResult();
            }
        }
    }
}
