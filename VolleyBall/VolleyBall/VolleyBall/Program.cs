using VolleyBall.Core;
using VolleyBall.Infrastructure;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

Log.Logger= new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var host = CreateHostBuilder(args);
host.Build().Services.GetRequiredService<IMatch>().PlayMatch();


static IHostBuilder CreateHostBuilder(string[] args){

    var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            services.Configure<MatchConfiguration>(configuration.GetSection("MatchConfiguration"));

            services.AddSingleton<IMatch, Match>();
        });

    return hostBuilder;
}


