using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Planifiqator.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
            }
            else
            {
                host.Run();
            }   
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using ( var scope = scopeFactory.CreateScope()) {
                var seeder = scope.ServiceProvider.GetService<DatabaseSeeder>();
                seeder.Seed();
            }
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).
                ConfigureAppConfiguration(AddConfiguration).
                UseStartup<Startup>()
                .Build();

        private static void AddConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json",false,true)
                .AddEnvironmentVariables();
            
        }
    }
}
