using System;

namespace Tasel.Shared.Hangfire
{
    public interface IJobRunner
    {
        IJobRunner Enqueue<TJob, TJobOptions>(Action<TJobOptions> configureJob)
            where TJobOptions : IJobOptions
            where TJob : IJob<TJobOptions>;

        IJobRunner Schedule<TJob, TJobOptions>(Action<TJobOptions> configureJob)
            where TJobOptions : IJobOptions
            where TJob : IJob<TJobOptions>;

        IJobRunner AddOrUpdate<TJob, TJobOptions>(Action<TJobOptions> configureJob, string cronExpression)
            where TJobOptions : IJobOptions
            where TJob : IJob<TJobOptions>;
    }
}