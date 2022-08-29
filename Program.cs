/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();*/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace BuyThis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //BuildWebHost(args).Run();
        }

        //  public static IWebHost BuildWebHost(string[] args) =>
        //  WebHost.CreateDefaultBuilder(args)
        //.ConfigureAppConfiguration(SetupConfiguration)
        //      .UseStartup<Startup>()
        //      .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(AddConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddConfiguration(HostBuilderContext ctx, IConfigurationBuilder bldr)
        {
            bldr.Sources.Clear();

            bldr.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json")
                .AddEnvironmentVariables();

        }
        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //remove default configuration objects so that we can customize this to the core
            builder.Sources.Clear();

            //asp.net used to use web.config but this was cumbersome.
            //aspnetcore however provides a more flexible configuration system
            //several different types of configuration options available
            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true)
              //.AddXmlFile("config.xml", optional: true)
              .AddEnvironmentVariables();
        }
    }
}

