using Task.Application.Models.TeamSchedule.GetScheduleByTeam;
using Task.Shared.OperationResponse;

namespace Task.Application.Contracts
{
    public interface ITeamScheduleService
    {
        Task<OperationResult<GetScheduleTeamResponse>> GetSchedule(int id);
    }
}
