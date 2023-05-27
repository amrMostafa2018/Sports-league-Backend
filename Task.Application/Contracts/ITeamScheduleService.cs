using Task.Application.Models.TeamSchedule.Add;
using Task.Application.Models.TeamSchedule.Get;
using Task.Application.Models.TeamSchedule.GetScheduleByTeam;
using Task.Shared.OperationResponse;

namespace Task.Application.Contracts
{
    public interface ITeamScheduleService
    {
        Task<OperationResult<GetAllTeamScheduleResponse>> GetAll();
        Task<OperationResult<GetScheduleTeamResponse>> GetSchedule(int id);
        Task<OperationResult<int>> Add(TeamScheduleRequest teamScheduleRequest);
    }
}
