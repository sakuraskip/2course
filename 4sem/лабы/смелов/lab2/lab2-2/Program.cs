using Microsoft.Extensions.FileProviders;

namespace lab2_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseWelcomePage("/aspnetcore");
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "neumann.html"}
            });
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Picture")),RequestPath = "/Picture"
            //});
            app.Map("/static", stapp =>
            {

                stapp.UseStaticFiles();
            });
            app.UseRouting();



            app.Run();
        }
    }
}
