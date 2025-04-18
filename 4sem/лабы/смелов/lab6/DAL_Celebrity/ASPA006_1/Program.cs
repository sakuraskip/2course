using Microsoft.Extensions.Options;
using _3DAL_Celebrity_MSSQL;
using DAL_Celebrity;
using Microsoft.AspNetCore.Diagnostics;

namespace ASPA006_1
{
    public class CelebrityConfig
    {
        public string PhotosFolder { get; set; }
        public string connectionString { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<CelebrityConfig>(builder.Configuration.GetSection("Celebrities"));
            builder.Services.AddScoped<IRepository, Repository>((IServiceProvider p) =>
            {
                CelebrityConfig config = p.GetRequiredService<IOptions<CelebrityConfig>>().Value;
                return new Repository(config.connectionString);
            });
            var app = builder.Build();

            var celebrities = app.MapGroup("/api/Celebrities");
            app.UseExceptionHandler("/Error");
            celebrities.MapGet("/", (IRepository repo) => Results.Ok(repo.getAllCelebrities())); // все
            celebrities.MapGet("/{id:int:min(1)}", (IRepository repo, int id) => // по айди
            {
                return Results.Ok(repo.getCelebrityById(id));
            });
            celebrities.MapGet("/Lifeevents/{id:int:min(1)}", (IRepository repo, int id) => // по айди события
            {
                var lifeevent = repo.GetCelebrityByLifeeventId(id);
                return Results.Ok(lifeevent);
            });
            celebrities.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                repo.delCelebrityById(id);
                return Results.Ok();
            });
            celebrities.MapPost("/", (IRepository repo, Celebrity celebrity) =>
            {
                repo.addCelebrity(celebrity);
                return Results.Ok(); 
            });
            celebrities.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebrity) =>
            {
                repo.updCelebrity(id, celebrity);
                return Results.Ok();
            });
            celebrities.MapGet("/photo/{fname}", async (IOptions<CelebrityConfig> iconfig, HttpContext context, string fname) =>
            {
                string photopath = iconfig.Value.PhotosFolder;
                if(photopath== null)
                {
                    return Results.NotFound();
                }
                string filepath = Path.Combine(photopath, fname);

                if (!File.Exists(filepath))
                {
                    return Results.NotFound();
                }
                var filebytes = await File.ReadAllBytesAsync(filepath);
                var contentType = "image/jpg";
                return Results.File(filebytes, contentType, fname);
            });

            var lifeevents = app.MapGroup("/api/Lifeevents");
            lifeevents.MapGet("/", (IRepository repo) => Results.Ok(repo.getAllLifeevents())); 
            lifeevents.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                var lifeevent = repo.getLifeeventById(id);
                return Results.Ok(lifeevent);
            });
            lifeevents.MapGet("/Celebrities/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                var lifeeventsList = repo.GetLifeeventsByCelebrityId(id);
                return Results.Ok(lifeeventsList);
            });
            lifeevents.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                repo.delLifeeventById(id);
                return Results.Ok();
            });
            lifeevents.MapPost("/", (IRepository repo, Lifeevent lifeevent) =>
            {
                repo.addLifeevent(lifeevent);
                return Results.Ok(); 
            });
            lifeevents.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Lifeevent lifeevent) =>
            {
                repo.updLifeevent(id, lifeevent);
                return Results.Ok();
            });
            app.Map("/Error", (HttpContext ctx) =>
            {
                Exception? ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
                return Results.Ok(new { message = ex?.Message });
            });
            app.Run();
        }
    }
}