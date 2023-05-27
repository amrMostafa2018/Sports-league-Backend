using Hangfire;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Tasel.Shared.Hangfire
{
    public class JobRunner : IJobRunner
    {
        private IBackgroundJobClient BackgroundJobClient { get; }

        public JobRunner(IApplicationBuilder app)
        {
            BackgroundJobClient = app.ApplicationServices.GetService<IBackgroundJobClient>();
        }

        public JobRunner(IBackgroundJobClient backgroundJobClient)
        {
            BackgroundJobClient = backgroundJobClient;
        }

        public IJobRunner Enqueue<TJob, TJobOptions>(Action<TJobOptions> configureJob) where TJob : IJob<TJobOptions> where TJobOptions : IJobOptions
        {
            var jobOptions = Activator.CreateInstance<TJobOptions>();
            configureJob(jobOptions);
            BackgroundJobClient.Enqueue<TJob>(job => job.Perform(jobOptions));
            return this;
        }

        public IJobRunner Schedule<TJob, TJobOptions>(Action<TJobOptions> configureJob) where TJob : IJob<TJobOptions> where TJobOptions : IJobOptions
        {
            var jobOptions = Activator.CreateInstance<TJobOptions>();
            configureJob(jobOptions);
            BackgroundJobClient.Schedule<TJob>(job => job.Perform(jobOptions),TimeSpan.FromHours(7));
            return this;
        }

        public IJobRunner AddOrUpdate<TJob, TJobOptions>(Action<TJobOptions> configureJob, string cronExpression) where TJob : IJob<TJobOptions> where TJobOptions : IJobOptions
        {
            var jobOptions = Activator.CreateInstance<TJobOptions>();
            configureJob(jobOptions);
            RecurringJob.RemoveIfExists(nameof(TJob));
            RecurringJob.AddOrUpdate<TJob>(job => job.Perform(jobOptions), cronExpression);
            return this;
        }
    }
}