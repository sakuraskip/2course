using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace webApi_DLL
{
    public class CelebritiesConfig
    {
        public string PhotosFolder {  get; set; }
        public string ConnectionString { get; set; }
        public string PhotosRequestPath { get; set; }

        public CelebritiesConfig()
        {
            this.PhotosRequestPath = "/Photos";
            this.PhotosFolder = "C:\\norus\\Photos";
            this.ConnectionString = "Data source = leksus\\SQLEXPRESS; Initial Catalog = Celebrities;TrustServerCertificate=Yes;Integrated Security=True;"
;        }

        

       
    }
    public static class CelebrityConfig
    {
        public static IServiceCollection AddCelebritiesConfiguration(this WebApplicationBuilder builder,
           string celebrityjson = "Celebriries.config.json")
        {
            builder.Configuration.AddJsonFile(celebrityjson);
            return builder.Services.Configure<CelebritiesConfig>(builder.Configuration.GetSection("Celebrities"));
        }
        public static IServiceCollection AddCelebritiesServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository, Repository>((IServiceProvider p) =>
            {
                CelebritiesConfig config = p.GetRequiredService<IOptions<CelebritiesConfig>>().Value;
                return new Repository(config.ConnectionString);
            });
            return builder.Services;
        }
    }
}
