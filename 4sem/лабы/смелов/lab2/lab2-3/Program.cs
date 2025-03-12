using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics",LogLevel.None);

        var app = builder.Build();

        app.UseExceptionHandler("/error");

        // Генерация исключения
        app.MapGet("/", () => "start ");
        app.MapGet("/test1", () =>
            {
                throw new Exception("-- exception test -- ");
            });

        app.MapGet("/test2", () =>
        {
            int x = 0, y = 5, z = 0;
            z = y / x;
            return "test2";
        });


        // Пример маршрута
        app.MapGet("/test3", () =>
        {
            int[] x = new int[3] { 1, 2, 3 };
            int y = x[3];
            return "test3";
        });

        app.MapGet("/error", async (ILogger<Program> logger, HttpContext context) =>
        {
            IExceptionHandlerFeature? exobj = context.Features.Get<IExceptionHandlerFeature>();
            await context.Response.WriteAsync($"<h1>error((((((???</h1><p>{exobj.Error.Message}</p>");
            logger.LogError(exobj?.Error, "exceptionhandler");
        });

        app.Run();
    }
}