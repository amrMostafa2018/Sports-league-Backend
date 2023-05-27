using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;
using Task.Shared.Common;

namespace Task.Shared.Logging
{
    public static class Extensions
    {
        [Obsolete]
        public static IWebHostBuilder ConfigureLogging(this IWebHostBuilder webHostBuilder, string applicationName = null)
        {
           return webHostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
               
                var seqOptions = context.Configuration.GetOptions<SeqOptions>("seq");

                var serilogOptions = context.Configuration.GetOptions<SerilogOptions>("serilog");
                if (!Enum.TryParse<LogEventLevel>(serilogOptions.Level, true, out var level))
                {
                    level = LogEventLevel.Information;
                }

                applicationName = string.IsNullOrWhiteSpace(applicationName) ? "Task" : applicationName;
                loggerConfiguration
                    .MinimumLevel.Is(level)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName)
                    .WriteTo.File(serilogOptions.LoggingFilePath, rollingInterval: RollingInterval.Day,
                        outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] [{ApplicationName}, {EnvironmentUserName}, {Environment}]: {Message: lj}{NewLine}{Exception}");

                Configure(loggerConfiguration, level, seqOptions, serilogOptions);
            });
        }

        private static void Configure(LoggerConfiguration loggerConfiguration, LogEventLevel level, SeqOptions seqOptions, SerilogOptions serilogOptions)
        {
            if (serilogOptions.ConsoleEnabled)
            {
                loggerConfiguration.WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {EnvironmentUserName}{EnvironmentUserName}: {Message: lj}{NewLine}{Exception}");
            }

            if (seqOptions.Enabled)
            {
                loggerConfiguration.WriteTo.Seq(seqOptions.Url, apiKey: seqOptions.ApiKey);
            }
        }
    }
}