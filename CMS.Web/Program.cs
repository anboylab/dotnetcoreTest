using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args) // Return IWebHostBuilder
                .Build()    // Build IWebHost
                .Run();     // Run IWebHost(WebAPP���ε{��) �Ұʤ@���B���ťhttp�ШD
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // �ϥ��q�{�t�m�T���ϥv�ܤ@�ӷs��IWebHostBuilder���
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Web Host ���wStartup
            })

            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                      .AddJsonFile("Content.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();
            });
    }
}
