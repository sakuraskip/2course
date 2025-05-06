using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MSSQL = _3DAL_Celebrity_MSSQL;
using REPO = DAL_Celebrity;
namespace lab7.Pages
{
    public class CelebritiesModel : PageModel
    {
        public List<MSSQL.Celebrity> Celebrities { get; set; } = new List<Celebrity>();

        MSSQL.IRepository repo;
        public CelebritiesModel(MSSQL.IRepository repo) {  this.repo = repo; }

        public ActionResult OnGet()
        {
            this.Celebrities = this.repo.getAllCelebrities().ToList();
            return Page();
        }
        
    }
}
