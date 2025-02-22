namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//��������� ������� ����������
            builder.Services.AddHttpLogging(log =>
            {
                log.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestMethod | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPath |
                Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseStatusCode;
            });
           
            var app = builder.Build();//�������� ����������
            app.UseHttpLogging();

            app.MapGet("/", () => "��� ������ aspa");//�������� ����������� GET ��������
            //���������� ������ ������ 
            app.Run();

        }
    }
}
