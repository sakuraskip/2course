using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;

namespace aspa008
{
    public class AsyncFilter : Attribute,IAsyncActionFilter
    {
        public static readonly string Wikipedia = "WIKI";
        public static readonly string Facebook = "FACE";

        string infotype;
        public AsyncFilter(string infotype = " ")
        {

        this.infotype = infotype; }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {
            IRepository? repo = context.HttpContext.RequestServices.GetService<IRepository>();
            int id = (int)(context.ActionArguments["id"]??-1);
            Celebrity? celebrity = repo?.getCelebrityById(id);
            if (infotype.ToUpper().Contains(Wikipedia)&& celebrity!= null)
            {
                context.HttpContext.Items.Add(Wikipedia, getFromWiki(celebrity.FullName));
            }
            if(infotype.ToUpper().Contains(Facebook)&& celebrity!= null)
            {
                context.HttpContext.Items.Add(Facebook, getFromFace(celebrity.FullName));

            }
            await next();
        }
        string getFromWiki(string fullname)
        {
            string rc = "Info from Wiki";
            return rc;
        }
        string getFromFace(string fullname)
        {
            string rc = "Infp frpm Face";
            return rc;
        }
    }
}
