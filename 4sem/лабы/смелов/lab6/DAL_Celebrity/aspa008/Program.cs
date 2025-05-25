using webApi_DLL;
using DAL_Celebrity;
using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc;
namespace aspa008
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddCelebritiesConfiguration();
            builder.AddCelebritiesServices();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseANCErrorHandler("ANC27X");
            app.MapRazorPages();
            app.MapCelebrities();
            // API Lifeevents
            app.MapLifeevents();
            // API для фотографий
            app.MapPhotoCelebrities(null);
            app.MapControllerRoute( //новая
                name: "celebrity",
                pattern: "/0",
                defaults: new { Controller = "Celebrities", Action = "NewHumanForm" });
            app.MapControllerRoute( //новая
              name: "celebrity",
              pattern: "/{id:int:min(1)}",
              defaults: new { Controller = "Celebrities", Action = "Human" });
            app.MapControllerRoute( //новая
             name: "default",
             pattern: "{controller = Celebrities}/{action= Index}/{id?}");
          

            app.Run();
        }
    }
}
