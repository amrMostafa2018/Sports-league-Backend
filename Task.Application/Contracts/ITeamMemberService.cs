using Task.Application.Models.Team.Add;
using Task.Application.Models.TeamMember.Add;
using Task.Application.Models.TeamMemeber.Edit;
using Task.Application.Models.TeamMemeber.Get;
using Task.Shared.OperationResponse;

namespace Task.Application.Contracts
{
    public interface ITeamMemberService
    {
        Task<OperationResult<GetAllTeamMemebrsResponse>> GetAll(int teamId);
        Task<OperationResult<int>> Add(TeamMemberRequest teamMemberRequest);
        Task<OperationResult<bool>> Edit(EditTeamMemberRequest editTeamMemberRequest);
        Task<OperationResult<bool>> Delete(int id);


    }
}
