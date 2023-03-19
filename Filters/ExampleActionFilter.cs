using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcFilterPipesApp.Filters
{
    public class LastJoinActionFilter : Attribute, IResourceFilter //, IOrderedFilter
    {
        //public int Order { get; }
        //public LastJoinActionFilter(int order) => Order = order;

        string email;

        public LastJoinActionFilter(string email)
        {
            this.email = email;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastJoin", DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss"));
            context.HttpContext.Response.Cookies.Append("Email", email);
        }
    }
}
