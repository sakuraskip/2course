namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseWelcomePage("/aspnetcore");
            app.UseStaticFiles();
            

           

            
            app.Run();
        }
    }
}
