using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using webApi_DLL;

namespace aspa008.Controllers
{
    public class CelebritiesController : Controller
    {
        IRepository repo;
        IOptions<CelebritiesConfig> options;
        public CelebritiesController(IRepository repo,IOptions<CelebritiesConfig> options)
        {
            this.repo = repo;
            this.options = options;
        }
        public record IndexModel(string PhotosRequestPath,List<Celebrity> Celebrities);
        public IActionResult Index()
        {
            return View(new IndexModel(options.Value.PhotosRequestPath,repo.getAllCelebrities()));
        }
        public record HumanModel(string photoreqpath,Celebrity celebrity,List<Lifeevent> lifeevents,List<string>info);
        [AsyncFilter(infotype:"Wikipedia,facebook")]
        public IActionResult Human(int id)
        {
            IActionResult rc = NotFound();
            Celebrity? celebrity = repo.getCelebrityById(id);
            List<string> info = new List<string> { (string)(HttpContext.Items[AsyncFilter.Wikipedia]??""),
            (string)(HttpContext.Items[AsyncFilter.Facebook]??"")};
            return View();
        }
    }
}
