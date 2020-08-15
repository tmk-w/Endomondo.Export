using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Endomondo.Export
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    Console.WriteLine("Endomondo Export");
                    Console.WriteLine();

                    Run(options).Wait();
                });
        }

        private static Task Run(Options options)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((b, c) =>
                {
                    c.AddSingleton(options);
                    c.AddScoped<IGpxParser, GpxParser>();
                    c.AddScoped<IFileService, FileService>();
                    c.AddHttpClient<EndomondoClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://api.mobile.endomondo.com");
                    });
                    c.AddHostedService<ConsoleService>();
                })
                .ConfigureLogging(bldr =>
                {
                    bldr.ClearProviders();
                    bldr.AddConsole()
                        .SetMinimumLevel(LogLevel.Error);
                })
                .RunConsoleAsync();
        }
    }
}
