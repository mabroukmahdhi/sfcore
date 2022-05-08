// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TSApiTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
