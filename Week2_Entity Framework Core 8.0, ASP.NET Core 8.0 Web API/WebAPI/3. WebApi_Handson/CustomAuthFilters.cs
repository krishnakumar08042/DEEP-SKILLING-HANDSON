
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiDemo.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token) ||
                !token.ToString().Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token or Bearer missing");
            }
        }
    }
}