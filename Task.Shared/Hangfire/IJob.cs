using System.Threading.Tasks;

namespace Tasel.Shared.Hangfire
{
    public interface IJob<in TJobOptions> where TJobOptions : IJobOptions
    {
        Task Perform(TJobOptions jobOptions);
    }
}