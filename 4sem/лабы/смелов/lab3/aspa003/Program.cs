using dAL003;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Authentication;

namespace aspa003
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDirectoryBrowser();

            var app = builder.Build();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/celebrities/download"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/Photo"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/celebrities/download",
                
               
            });

         

            using (IRepository repository = new Repository("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\смелов\\lab3\\test_dal003\\Photo\\Celebrities.json"))
            {
                app.MapGet("/Celebrities", () => repository.getAllCelebrities());
                app.MapGet("/Celebrities/{id:int}", (int id) => repository.getCelebrityById(id));
                app.MapGet("/Celebrities/BySurname/{surname}", (string surname) => repository.getCelebritiesBySurname(surname));
                app.MapGet("/Celebrities/PhotoPathById/{id:int}", (int id) => repository.getPhotoPathById(id));
                app.MapGet("/celebrities/download/{filename}", (HttpContext context, string filename) =>
                {
                    if(filename.Contains("json"))
                    {
                        return downfile(context, filename, "file/json");
                    }
                    return downfile(context, filename, "image/jpg");
                });
                app.Run();
            }
        }
        static IResult downfile(HttpContext context, string filename, string mime)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            if (System.IO.File.Exists(filePath))
            {
                context.Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{filename}\"");
                return Results.File(filePath, mime);
            }
            else
            {
                return Results.NotFound();
            }
        }
    }
}