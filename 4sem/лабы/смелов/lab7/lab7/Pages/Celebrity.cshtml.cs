using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _3DAL_Celebrity_MSSQL;
using webApi_DLL;
using DAL_Celebrity;
using Microsoft.Extensions.Options;
using static webApi_DLL.ErrorHandler;
namespace lab7.Pages
{
    public class CelebrityModel : PageModel
    {

        public Celebrity? celebrity { get; set; }
        public string? PhotosRequestPath;
        IRepository repo;

        [BindProperty(SupportsGet = true)]
        public Parms? ModelParms { get; set; }


        public CelebrityModel(IRepository repo, IOptions<CelebritiesConfig> conf)
        {
            this.repo = repo;
            PhotosRequestPath = conf.Value.PhotosRequestPath;
        }
        public ActionResult OnGet(int id)
        {
            if (ModelParms == null || ModelParms.Id == null || ModelParms.Repo == null || ModelParms.Config == null)
            {
                throw new ANC25Exception(
                    status: 500,
                    code: "500001",
                    detail: "CelebrityModel",
                    message: "ParamsModel is invalid");
            }

            this.PhotosRequestPath = ModelParms.Config.Value.PhotosRequestPath;
            this.celebrity = ModelParms.Repo.getCelebrityById((int)ModelParms.Id);

            if (this.celebrity == null)
            {
                return NotFound();
            }

            return ModelParms.AcceptMIMO == "json"
                ? this.RedirectToRoute("GetCelebrityById", new { Id = ModelParms.Id })
                : Page();
        }
        public class Parms
        {
            [FromRoute]
            public int? Id { get; set; }

            [FromQuery(Name = "id")]
            public int? QueryId { get; set; }

            [FromHeader(Name = "Accept")]
            public string? AcceptHeader { get; set; }

            [FromServices]
            public IRepository? Repo { get; set; }

            [FromServices]
            public IOptions<CelebritiesConfig>? Config { get; set; }

            public string AcceptMIMO
            {
                get
                {
                    return PreferredAcceptMIMO(AcceptHeader, new string[] { "json", "html" }).Item1;
                }
            }

            private (string?, int) PreferredAcceptMIMO(string? accept, string[] parms)
            {
                (string?, int) rc = (null, -1);
                if (accept != null)
                {
                    int k = -1, mink = accept.Length + 1, mini = -1;
                    for (int i = 0; i < parms.Length; i++)
                    {
                        if ((k = accept.IndexOf(parms[i], StringComparison.OrdinalIgnoreCase)) >= 0)
                            if (k < mink) { mink = k; mini = i; }
                    }
                    rc = ((mini > 0) ? parms[mini] : null, mini);
                }
                return rc;
            }
        }
    }
}
