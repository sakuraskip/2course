using _3DAL_Celebrity_MSSQL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = "Data source = leksus\\SQLEXPRESS; Initial Catalog = Celebrities; TrustServerCertificate = Yes; Integrated Security = True;";
            // Add services to the container.
            builder.Services.AddScoped<IRepository, Repository>((IServiceProvider p) => new Repository(connectionString));
            builder.Services.AddRazorPages(p =>
            {
                p.Conventions.AddPageRoute("/Celebrities", "/");
                p.Conventions.AddPageRoute("/NewCelebrity", "/0");
                p.Conventions.AddPageRoute("/Celebrity", "/Celebrities/{id:int:min(1)}");
                p.Conventions.AddPageRoute("/Celebrity", "/{id:int:min(1)}");


            });
                

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
