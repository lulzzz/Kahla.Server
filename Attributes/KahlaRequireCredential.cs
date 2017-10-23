using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kahla.Server.Attributes
{
    public class KahlaRequireCredentialAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var credential = context.HttpContext.Request.Query["credential"];
            if(string.IsNullOrEmpty(credential))
            {
                context.HttpContext.Response.Redirect("/notsignin");
            }
        }
    }
}
