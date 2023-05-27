using Task.Application.Models.Team.Add;
using Task.Application.Models.Team.Edit;
using Task.Application.Models.Team.Get;
using Task.Application.Models.Team.GetById;
using Task.Shared.OperationResponse;

namespace Task.Application.Contracts
{
    public interface ITeamService
    {
        Task<OperationResult<GetAllTeamsResponse>> GetAll();
        Task<OperationResult<GetTeamDetailsResponse>> GetById(int id);
        Task<OperationResult<int>> Add(TeamRequest teamRequest);
        Task<OperationResult<bool>> Edit(EditTeamRequest editTeamRequest);
        Task<OperationResult<bool>> Delete(int id);


    }
}
