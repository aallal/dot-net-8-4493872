using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
namespace App;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        builder.ConfigureAppConfiguration((context, config) =>
        {
            // Configure app configuration here
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        })
        ;
        builder.ConfigureServices((context, services) =>
            {
                // Register services here
                services.AddHostedService<AppService>(
                    provider =>
                    {
                        string msg = context.Configuration.GetValue<string>("options:msg") ?? "Hello, World!";
                        return new AppService(msg);
                    }
                );
            });
        using var host = builder.Build();
        host.Run();
    }
}
