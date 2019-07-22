using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                // Informs the app to use the ocelot.json file
                config.AddJsonFile("ocelot.json");
            })
            .ConfigureServices(s =>
            {
                // Enables injection of service
                // dependencies of Ocelot.
                s.AddOcelot();
            })
            .Configure(app =>
            {
                // Includes Ocelot middleware.
                app.UseOcelot().Wait();
            });
    }
}
