using _3DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static webApi_DLL.ErrorHandler;
namespace webApi_DLL
{
    public static class CelebrityAPI
    {
        public static RouteHandlerBuilder MapCelebrities(this IEndpointRouteBuilder builder,
            string prefix = "/api/Celebrities")
        {
            var celebrities = builder.MapGroup(prefix);

            celebrities.MapGet("/",(IRepository repo)=> repo.getAllCelebrities());
            celebrities.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.getCelebrityById(id);
                if (celebrities == null) throw new ANC25Exception(status: 404, code: "404001", detail: $"Celebrity id= {id}");
                return Results.Ok(celebrity);
            });
            celebrities.MapGet("/Lifeevents/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.GetCelebrityByLifeeventId(id);
                if (celebrities == null) throw new ANC25Exception(status: 404, code: "404001", detail: $"Celebrity id= {id}");
                return Results.Ok(celebrity);
            });
            celebrities.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.getCelebrityById(id);
                if (celebrities == null) throw new ANC25Exception(status: 404, code: "404001", detail: $"Celebrity id= {id}");
                repo.delCelebrityById(id);
                return Results.Ok();
            });
            celebrities.MapPost("/", (IRepository repo, Celebrity celebrity) =>
            {
                if (repo.addCelebrity(celebrity))
                {
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest();
                }

            });
            celebrities.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebity) =>
            {
                if (repo.updCelebrity(id, celebity))
                {
                    return Results.Ok();
                }
                return Results.BadRequest();
            });
            return celebrities.MapGet("/photo/{fname}", async (IOptions<CelebritiesConfig> iconfig, HttpContext context, string fname) =>
            {
                string photopath = iconfig.Value.PhotosFolder;
                if (photopath == null) throw new Exception("Photo path is null.");

                string filepath = Path.Combine(photopath, fname);
                if (!File.Exists(filepath)) throw new Exception($"File '{fname}' not found.");

                var filebytes = await File.ReadAllBytesAsync(filepath);
                var contentType = "image/jpg";
                return Results.File(filebytes, contentType, fname);
            });
        }
        public static RouteHandlerBuilder MapPhotoCelebrities(this IEndpointRouteBuilder routeBuilder,string? prefix = "/Photos")
        {
            if(string.IsNullOrEmpty(prefix)) prefix = routeBuilder.ServiceProvider.GetRequiredService<IOptions<CelebritiesConfig>>().Value.PhotosRequestPath;
            return routeBuilder.MapGet($"{prefix}/{{fname}}", async (IOptions<CelebritiesConfig> iconfig, HttpContext context, string fname) =>
            {
                CelebritiesConfig config = iconfig.Value;
                string filepath = Path.Combine(config.PhotosFolder, fname);
                FileStream file = File.OpenRead(filepath);
                BinaryReader sr = new BinaryReader(file);
                BinaryWriter wr = new BinaryWriter(context.Response.BodyWriter.AsStream());
                int n = 0; byte[] buffer = new byte[2048];
                context.Response.ContentType = "image/jpeg";
                context.Response.StatusCode = StatusCodes.Status200OK;
                while ((n = await sr.BaseStream.ReadAsync(buffer, 0, 2048)) > 0) await wr.BaseStream.WriteAsync(buffer, 0, n);
                sr.Close(); wr.Close();
            });
        }
        public static RouteHandlerBuilder MapLifeevents(this IEndpointRouteBuilder routeBuilder,
            string prefix = "/api/Lifeevents")
        {
            var lifeevents = routeBuilder.MapGroup(prefix);

            lifeevents.MapGet("/", (IRepository repo) => repo.getAllLifeevents());

            lifeevents.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
               var events = repo.getLifeeventById(id);
                if(events!= null)
                {
                    return Results.Ok(events);
                }
                return Results.NotFound();
            });
            lifeevents.MapGet("/Celebrities/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                var events = repo.GetLifeeventsByCelebrityId(id);
                if (events != null)
                {
                    return Results.Ok(events);
                }
                return Results.NotFound();
            });
            lifeevents.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                if (repo.delLifeeventById(id))
                {
                    return Results.Ok(id);
                }
                return Results.NotFound(id);
            });
            lifeevents.MapPost("/", (IRepository repo, Lifeevent lifevent) =>
            {
                Celebrity? c = repo.getCelebrityById(lifevent.CelebrityId);
                if (c == null) throw new ANC25Exception(status: 404, code: "404001",detail: "404002:Lifeevent");
                if (!repo.addLifeevent(lifevent)) throw new ANC25Exception(status: 500, code: "500005", detail: $"addlifeevent()");
                return Results.Ok(lifevent);
            });
            return lifeevents.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Lifeevent lifevent) =>
            {
                if (repo.updLifeevent(id, lifevent))
                {
                    return Results.Ok(lifevent);
                }
                return Results.NotFound(id);
            });
        }
    }
   
}
