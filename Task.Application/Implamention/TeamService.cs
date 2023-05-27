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
using Task.Application.Models.Team.Add;
using Task.Application.Models.Team.Get;
using Task.Application.Models.Team.Edit;
using Task.Application.Models.Team.GetById;
using Microsoft.EntityFrameworkCore;
using Task.Application.Models.TeamMember.Get;

namespace Task.Services.Implementation
{
    public class TeamService : SharedServices<TeamService>, ITeamService
    {
        private readonly ISharedRepository<Team, int> _teamRepository;
        public TeamService(ISharedRepository<Team, int> teamRepository,
                           IMapper mapper,
                           IStringLocalizer<Resource> localizer,
                           ILogger<TeamService> logger) : base(mapper, localizer, logger)
        {
            _teamRepository = teamRepository;
        }


        public async Task<OperationResult<GetAllTeamsResponse>> GetAll()
        {
            try
            {
                _logger.LogInformation($"Start GetAll Method In Team Service");
                var teams = _teamRepository.Find(c => !c.IsDeleted).OrderByDescending(n => n.CreationDate).ToList();
                GetAllTeamsResponse getAllTeamsResponse = new GetAllTeamsResponse()
                {
                    Items = _mapper.Map<List<GetAllTeamModel>>(teams)
                };

                return OperationResult<GetAllTeamsResponse>.Success(getAllTeamsResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In GetAll Method In Team Service");
                return OperationResult<GetAllTeamsResponse>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }

        }
        public async Task<OperationResult<GetTeamDetailsResponse>> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Start GetById Method In Team Service");
                var team =  _teamRepository.Find(c =>c.Id == id && !c.IsDeleted).Include(m=>m.TeamMemebers).FirstOrDefault();
            
                if (team == null)
                {
                    _logger.LogInformation($"Team with Id : {id} is Null In GetById Method In Team Service");
                    return OperationResult<GetTeamDetailsResponse>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", id].Value);
                }
                GetTeamDetailsResponse getTeamDetailsResponse = new GetTeamDetailsResponse()
                {
                    TeamDetails = _mapper.Map<GetAllTeamModel>(team),
                    TeamMembers = _mapper.Map<List<GetAllTeamMemberModel>>(team.TeamMemebers)
                };
               
                return OperationResult<GetTeamDetailsResponse>.Success(getTeamDetailsResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In GetAll Method In Team Service");
                return OperationResult<GetTeamDetailsResponse>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<int>> Add(TeamRequest teamRequest)
        {
            try
            {
                _logger.LogInformation($"Start Add Method In Team Service");
                Team teamEnitity = _mapper.Map<Team>(teamRequest);
                await _teamRepository.Add(teamEnitity);

                return OperationResult<int>.Success(teamEnitity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Add Method In Team Service");
                return OperationResult<int>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }


        public async Task<OperationResult<bool>> Edit(EditTeamRequest editTeamRequest)
        {
            try
            {
                _logger.LogInformation($"Start Edit Team Method In Team Service");
                var teamResult = await _teamRepository.FindOneAsync(a => a.Id == editTeamRequest.Id && !a.IsDeleted);
                if (teamResult == null)
                {
                    _logger.LogInformation($"Team with Id : {editTeamRequest.Id} is Null In Edit Method In Team Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", editTeamRequest.Id].Value);
                }
                Team teamEnitity = _mapper.Map<Team>(editTeamRequest);
                teamEnitity.ModificationDate = DateTime.Now;
                await _teamRepository.Update(teamEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Edit Team Method In Team Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<bool>> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Start Delete Team Method In Team Service");
                var teamEnitity = await _teamRepository.FindOneAsync(a => a.Id == id && !a.IsDeleted);
                if (teamEnitity == null)
                {
                    _logger.LogInformation($"Team with Id : {id} is Null In Delete Method In Team Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", id].Value);
                }
                await _teamRepository.Delete(teamEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Delete Team Method In Team Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

     
    }
}
