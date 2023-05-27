using System;

namespace Tasel.Shared.Hangfire
{
    public class FakeJobRunner : IJobRunner
    {
        public IJobRunner AddOrUpdate<TJob, TJobOptions>(Action<TJobOptions> configureJob, string cronExpression)
            where TJob : IJob<TJobOptions>
            where TJobOptions : IJobOptions
        {
            return this;
        }

        public IJobRunner Enqueue<TJob, TJobOptions>(Action<TJobOptions> configureJob)
            where TJob : IJob<TJobOptions>
            where TJobOptions : IJobOptions
        {
            return this;
        }

        public IJobRunner Schedule<TJob, TJobOptions>(Action<TJobOptions> configureJob)
            where TJob : IJob<TJobOptions>
            where TJobOptions : IJobOptions
        {
            return this;
        }
    }
}