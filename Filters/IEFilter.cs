using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace MvcFilterPipesApp.Filters
{
    public class IEFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecuting(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            string browser = context.HttpContext.Request.Headers["User-Agent"].ToString();
            if (Regex.IsMatch(browser, "MSIE|Trident"))
                context.Result = new ContentResult() { Content = "Your browser is old" };
            else
                await next();
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            await next();
        }
    }
}
