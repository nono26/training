using Microsoft.AspNetCore;
using Microsoft.Extensions.Hosting;

namespace BankAccountAPI{

    public class Program{
        public static void Main(string[] args){

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            try{
                CreateWebHostBuilder(args)
                .Build()
                .Run();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)=>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}