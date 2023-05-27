using System;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tasel.Shared.Hangfire
{
    public static class Extensionss
    {
        public static void AddJobs(this IServiceCollection services)
        {
            var options = ConfigureOptions(services);
            if (options.EnableJobs)
            {
                // Add Hangfire services.
                services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(options.CONNECTION_STRING, new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        UsePageLocksOnDequeue = true,
                        DisableGlobalLocks = true
                    }));

                if (options.EnableServer)
                    services.AddHangfireServer();

                services.AddTransient<IJobRunner, JobRunner>();
            }
            else
            {
                services.AddTransient<IJobRunner, FakeJobRunner>();
            }
        }

        public static IJobRunner UseJobs(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<IConfiguration>()
               .GetOptions<HangfireOptions>("hangfire");
            if (!options.EnableJobs)
            {
                return new FakeJobRunner();
            }
            return new JobRunner(builder);
        }

        public static void UseJobsDashboard(this IApplicationBuilder builder)
        {
            builder.UseHangfireDashboard("/dashboard", new DashboardOptions()
            {
                Authorization = new[] { new HangfireAuthorizationFilter(builder) },
                AppPath = "/"
            });
        }

        private static HangfireOptions ConfigureOptions(IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.Configure<HangfireOptions>(configuration.GetSection("hangfire"));

            return configuration.GetOptions<HangfireOptions>("hangfire");
        }
    }
}