using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MSSQL = _3DAL_Celebrity_MSSQL;
using REPO = DAL_Celebrity;
using webApi_DLL;
namespace lab7.Pages
{
    public class CelebritiesModel : PageModel
    {
        public List<MSSQL.Celebrity> Celebrities { get; set; } = new List<Celebrity>();

        MSSQL.IRepository repo;
        public string PhotosRequestPath;
        public CelebritiesModel(MSSQL.IRepository repo,IOptions<CelebritiesConfig> conf) {  this.repo = repo;
     this.PhotosRequestPath = conf.Value.PhotosRequestPath;
        }

        public ActionResult OnGet()
        {
            this.Celebrities = this.repo.getAllCelebrities().ToList();
            return Page();
        }
        
    }
}
