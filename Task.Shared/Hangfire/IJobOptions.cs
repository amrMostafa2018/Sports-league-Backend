namespace Tasel.Shared.Hangfire
{
    public interface IJobOptions
    {
        string CronExpression { get; set; } 
    }
}