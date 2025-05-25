using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace webApi_DLL
{
    public class CelebritiesConfig
    {
        public string PhotosFolder {  get; set; }
        public string ConnectionString { get; set; }
        public string PhotosRequestPath { get; set; }
        public string IsoPath { get;set; }
        public CelebritiesConfig()
        {
            this.PhotosRequestPath = "/Photos";
            this.PhotosFolder = "C:\\norus\\Photos";
            this.ConnectionString = "Data source = leksus\\SQLEXPRESS; Initial Catalog = Celebrities;TrustServerCertificate=Yes;Integrated Security=True;";
            this.IsoPath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\смелов\\lab6\\DAL_Celebrity\\aspa008\\CountryCodes\\countrycodes.json";

;        }
    }
    public class CountryCodes: List<CountryCodes.ISOCountryCodes>
    {
        public record ISOCountryCodes(string code,string countryLabel);
        public CountryCodes(string jsoncountrycodepath) : base()
        {
            if(File.Exists(jsoncountrycodepath))
            {
                FileStream fs = new FileStream(jsoncountrycodepath,FileMode.OpenOrCreate,FileAccess.Read);
                List<ISOCountryCodes>? cc = JsonSerializer.DeserializeAsync<List<ISOCountryCodes>>(fs).Result;
                if (cc != null) this.AddRange(cc);
            }
        }
    }
    public static class CelebrityConfig
    {
        public static IServiceCollection AddCelebritiesConfiguration(this WebApplicationBuilder builder,
           string celebrityjson = "Celebrities.config.json")
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
            builder.Services.AddSingleton<CountryCodes>((p)=>new CountryCodes(p.GetRequiredService<IOptions<CelebritiesConfig>>().Value.IsoPath));
            return builder.Services;
        }
    }
}
