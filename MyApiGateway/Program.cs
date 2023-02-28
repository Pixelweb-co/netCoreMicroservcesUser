using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Hosting; 
using Ocelot.DependencyInjection; 
using Ocelot.Middleware; 
namespace MyApiGateway 
{ 
    public class Program 
    { 
        public static void Main(string[] args) 
        { 
         		CreateHostBuilder(args).Build().Run(); 
        }
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)

                ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.ConfigureServices(services => {
                        
                        services.AddOcelot(); 
                    });
                    
                    webBuilder.Configure(app => {
                        app.UseOcelot().Wait();
                    });
                });
    }
}