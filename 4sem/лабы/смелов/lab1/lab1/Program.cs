namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//экземпляр билдера приложения
            builder.Services.AddHttpLogging(log =>
            {
                log.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestMethod | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPath |
                Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseStatusCode;
            });
           
            var app = builder.Build();//создание приложения
            app.UseHttpLogging();

            app.MapGet("/", () => "МОЕ первое aspa");//создание обработчика GET запросов
            //приложение вернет строку 
            app.Run();

        }
    }
}
