using Microsoft.Extensions.Options;
using _3DAL_Celebrity_MSSQL;
using DAL_Celebrity;
namespace ASPA006_1
{
    public class CelebrityConfig
    {
        public string photosPath { get; set; }
        public string connectionString { get; set; }

     
    }
    public class Program
    {
        public readonly IOptions<CelebrityConfig> _options;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            builder.Services.Configure<CelebrityConfig>(builder.Configuration.GetSection("CelebrityConfig"));
            builder.Services.AddScoped<IRepository, Repository>((IServiceProvider p) =>
            {
                CelebrityConfig config = p.GetRequiredService<IOptions<CelebrityConfig>>().Value;
                return new Repository(config.connectionString);
            });

            var celebrities = app.MapGroup("/api/Celebrities");

            celebrities.MapGet("/", (IRepository repo) => repo.getAllCelebrities());//все
            celebrities.MapGet("/{id:int:min(1}", (IRepository repo, int id) =>//по айди
            {
                repo.getCelebrityById(id);
            });
            celebrities.MapGet("/Lifeevents/{id:int:min(1)}", (IRepository repo, int id) =>//по айди события
            {
                repo.GetCelebrityByLifeeventId(id);
            });
            celebrities.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                repo.delCelebrityById(id);
            });
            celebrities.MapPost("/", (IRepository repo, Celebrity celebrity) =>
            {
                repo.addCelebrity(celebrity);
            });
            celebrities.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebrity) =>
            {
                repo.updCelebrity(id, celebrity);
            });
            celebrities.MapGet("/photo/{fname}", async (IOptions<CelebrityConfig> iconfig, HttpContext context, string fname) =>
            {
                var photopath = iconfig.Value.photosPath;

            });
            app.Run();


        }
            
        }
    }
}
