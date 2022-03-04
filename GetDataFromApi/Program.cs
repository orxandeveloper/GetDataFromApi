using Convey;
using GDFA.Application.Config;
using GDFA.Application.Extensions;
using GDFA.Application.IServices;
using GDFA.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
 

namespace GetDataFromApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                }).ConfigureHostConfiguration(hostConfing =>//configuring Hosting
                {
                    Console.WriteLine(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT"));

                    var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

                    hostConfing.SetBasePath(Directory.GetCurrentDirectory());//Get directory of current project

                    hostConfing.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);// static congifuration Host by appsettings.json

                    hostConfing.AddJsonFile($"appsettings.{environment}.json",optional: true, reloadOnChange: true);  // configuration for every environment

                    hostConfing.AddEnvironmentVariables();//get all configuration variables from appsettings files
                    hostConfing.Build();


                }).ConfigureServices((hostContext,services) =>
                {
                    services.Configure<PostRestConfig>(hostContext.Configuration.GetSection("PostRestConfig"));// Get base url from configuration json file
                    services.AddScoped<IRestListenerService, RestListenerServices>();

                    services.AddConvey().AddApplication().Build();



                    services.AddHttpClient("posts");
                    services.AddHostedService<Worker>();
                });
    }
}
