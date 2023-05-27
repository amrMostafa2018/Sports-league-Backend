namespace Tasel.Shared.Hangfire
{
    public class HangfireOptions : IFromConfig
    {
        public bool EnableJobs { get; set; } = true;
        public string CONNECTION_STRING { get; set; }
        public bool EnableServer { get; set; }        
    }
}