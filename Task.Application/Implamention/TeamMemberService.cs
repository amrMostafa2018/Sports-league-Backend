using Task.Shared.Data.Repository;
using Task.Application.Contracts;
using Task.Shared.OperationResponse;
using Task.Shared.Services;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Task.Core.Resources;
using Microsoft.Extensions.Logging;
using Task.Shared.API;
using Task.Domain.Entites;
using Task.Application.Models.TeamMember.Add;
using Task.Application.Models.TeamMemeber.Get;
using Task.Application.Models.TeamMember.Get;
using Task.Application.Models.TeamMemeber.Edit;

namespace Task.Services.Implementation
{
    public class TeamMemberService : SharedServices<TeamMemberService>, ITeamMemberService
    {
        private readonly ISharedRepository<TeamMemeber, int> _teamMemberRepository;
        private readonly ISharedRepository<Team, int> _teamRepository;
        public TeamMemberService(ISharedRepository<TeamMemeber, int> teamMemberRepository,
                                 ISharedRepository<Team, int> teamRepository,
                                 IMapper mapper,
                                 IStringLocalizer<Resource> localizer,
                                 ILogger<TeamMemberService> logger) : base(mapper, localizer, logger)
        {
            _teamMemberRepository = teamMemberRepository;
            _teamRepository = teamRepository;
        }


        public async Task<OperationResult<GetAllTeamMemebrsResponse>> GetAll(int teamId)
        {
            try
            {
                _logger.LogInformation($"Start GetAll Method In Team Member Service");
                var teamResult = await _teamRepository.FindOneAsync(a => a.Id == teamId && !a.IsDeleted);
                if (teamResult == null)
                {
                    _logger.LogInformation($"Team with Id : {teamId} is Null In Add Method In Team Member Service");
                    return OperationResult<GetAllTeamMemebrsResponse>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", teamId].Value);
                }

                var teamMembers = _teamMemberRepository.Find(c => c.TeamId == teamId && !c.IsDeleted).ToList();
                GetAllTeamMemebrsResponse getAllTeamMembersResponse = new GetAllTeamMemebrsResponse()
                {
                    Items = _mapper.Map<List<GetAllTeamMemberModel>>(teamMembers)
                };

                return OperationResult<GetAllTeamMemebrsResponse>.Success(getAllTeamMembersResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In GetAll Method In Team Member Service");
                return OperationResult<GetAllTeamMemebrsResponse>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<int>> Add(TeamMemberRequest teamMemberRequest)
        {
            try
            {
                _logger.LogInformation($"Start Add Team Member Method In Team Member Service");
                var teamResult = await _teamRepository.FindOneAsync(a => a.Id == teamMemberRequest.TeamId && !a.IsDeleted);
                if (teamResult == null)
                {
                    _logger.LogInformation($"Team with Id : {teamMemberRequest.TeamId} is Null In Add Method In Team Member Service");
                    return OperationResult<int>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", teamMemberRequest.TeamId].Value);
                }

                var teamMemberHasSameNumber = await _teamMemberRepository.FindOneAsync(a => a.Number == teamMemberRequest.Number && a.TeamId == teamMemberRequest.TeamId && !a.IsDeleted);
                if (teamMemberHasSameNumber != null)
                {
                    _logger.LogInformation($"Team has Member with Same Number : {teamMemberRequest.Number}   In Add Method In Team Member Service");
                    return OperationResult<int>.Fail(HttpErrorCode.Conflict, CommonErrorCodes.NOT_FOUND, _localizer["TeamHasMemeberSameNumber", teamMemberRequest.Number].Value);
                }
                TeamMemeber teamMemeberEnitity = _mapper.Map<TeamMemeber>(teamMemberRequest);
                await _teamMemberRepository.Add(teamMemeberEnitity);

                return OperationResult<int>.Success(teamMemeberEnitity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Add Method In Team Member Service");
                return OperationResult<int>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }


        public async Task<OperationResult<bool>> Edit(EditTeamMemberRequest editTeamMemberRequest)
        {
            try
            {
                _logger.LogInformation($"Start Edit Team Member Method In Team Member Service");
                var teamResult = await _teamRepository.FindOneAsync(a => a.Id == editTeamMemberRequest.TeamId && !a.IsDeleted);
                if (teamResult == null)
                {
                    _logger.LogInformation($"Team with Id : {editTeamMemberRequest.TeamId} is Null In Edit Method In Team Member Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", editTeamMemberRequest.TeamId].Value);
                }

                var teamMemberHasSameNumber = await _teamMemberRepository.FindOneAsync(a => a.Number == editTeamMemberRequest.Number && a.TeamId == editTeamMemberRequest.TeamId && a.Id != editTeamMemberRequest.Id && !a.IsDeleted);
                if (teamMemberHasSameNumber != null)
                {
                    _logger.LogInformation($"Team has Member with Same Number : {editTeamMemberRequest.Number}   In Add Method In Team Member Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.Conflict, CommonErrorCodes.NOT_FOUND, _localizer["TeamHasMemeberSameNumber", editTeamMemberRequest.Number].Value);
                }
                TeamMemeber teamEnitity = _mapper.Map<TeamMemeber>(editTeamMemberRequest);
                teamEnitity.ModificationDate = DateTime.Now;
                await _teamMemberRepository.Update(teamEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Edit Team Member Method In Team Member Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<bool>> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Start Delete Team Member Method In Team Member Service");
                var teamNemberEnitity = await _teamMemberRepository.FindOneAsync(a => a.Id == id && !a.IsDeleted);
                if (teamNemberEnitity == null)
                {
                    _logger.LogInformation($"Team Member with Id : {id} is Null In Delete Method In Team Member Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamMemberNotFound", id].Value);
                }
                await _teamMemberRepository.Delete(teamNemberEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Delete Team Member Method In Team Member Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }
    }
}
