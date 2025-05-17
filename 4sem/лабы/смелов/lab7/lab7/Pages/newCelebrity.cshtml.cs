using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MSSQL = _3DAL_Celebrity_MSSQL;
using REPO = DAL_Celebrity;
using webApi_DLL;
using Microsoft.Extensions.Options;

namespace lab7.Pages
{
    public class NewCelebrityModel : PageModel
    {
        public IRepository repo;
        public string PhotosRequestPath { get; set; }
        public string PhotosFolder { get; set; }
        public Celebrity? celebrity { get; set; }

        public NewCelebrityModel(IRepository repo, IOptions<CelebritiesConfig> conf)
        {
            this.repo = repo;
            this.PhotosRequestPath = conf.Value.PhotosRequestPath;
            this.PhotosFolder = conf.Value.PhotosFolder;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(
     [FromForm] string? fullname,
     [FromForm] string? nationality,
     IFormFile file,
     string? buttonpressed,
     string? filename)
        {
            switch (buttonpressed)
            {
                case "ToMainPage":
                    return RedirectToPage("Celebrities");

                case "Confirm": 
                    string newfilename = $"{fullname.Replace(" ", "_")}.{filename}.jpg";
                    Directory.Move(
                        Path.Combine(this.PhotosFolder, filename),
                        Path.Combine(this.PhotosFolder, newfilename));
                    this.repo.addCelebrity(new Celebrity
                    {
                        FullName = fullname,
                        Nationality = nationality,
                        ReqPhotoPath = newfilename
                    });
                    return RedirectToPage("Celebrities");
                case "Cancel":
                    {
                        return RedirectToPage("NewCelebrity");
                    }
                default: 
                    string fname = Path.GetFileName(Path.GetTempFileName());
                    string photofile = Path.Combine(this.PhotosFolder, fname);
                    using (FileStream newfile = new FileStream(photofile, FileMode.CreateNew))
                    {
                        file.CopyTo(newfile);
                    }
                    return RedirectToPage("NewCelebrity", "Confirm", new
                    {
                        filename = fname,
                        fullname = fullname,
                        nationality = nationality
                    });
            }
        }
        public IActionResult OnGetConfirm(string fullname, string nationality, string filename)
        {
            ViewData["Confirm"] = true;
            this.celebrity = new Celebrity() { FullName = fullname, Nationality = nationality, ReqPhotoPath = filename };
            return Page();
        }
    }
}
