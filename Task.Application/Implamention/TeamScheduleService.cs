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
using Microsoft.EntityFrameworkCore;
using Task.Application.Models.TeamSchedule.GetScheduleByTeam;
using Task.Application.Models.TeamSchedule.Add;
using Task.Application.Models.TeamSchedule.Get;

namespace Task.Services.Implementation
{
    public class TeamScheduleService : SharedServices<TeamScheduleService>, ITeamScheduleService
    {
        private readonly ISharedRepository<Team, int> _teamRepository;
        private readonly ISharedRepository<TeamSchedule, int> _teamScheduleRepository;
        public TeamScheduleService(ISharedRepository<Team, int> teamRepository,
                           ISharedRepository<TeamSchedule, int> teamScheduleRepository,
                           IMapper mapper,
                           IStringLocalizer<Resource> localizer,
                           ILogger<TeamScheduleService> logger) : base(mapper, localizer, logger)
        {
            _teamRepository = teamRepository;
            _teamScheduleRepository = teamScheduleRepository;
        }


        public async Task<OperationResult<GetAllTeamScheduleResponse>> GetAll()
        {
            try
            {
                _logger.LogInformation($"Start GetAll Method Ins Team Schedule Service");
              
                var teamSchedule = _teamScheduleRepository.Find(n => !n.IsDeleted).Include(h => h.HomeTeam).Include(w => w.AwayTeam).ToList();
                GetAllTeamScheduleResponse getAllTeamScheduleResponse = new GetAllTeamScheduleResponse()
                {
                    Items = _mapper.Map<List<GetScheduleTeamModel>>(teamSchedule)
                };
                return OperationResult<GetAllTeamScheduleResponse>.Success(getAllTeamScheduleResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In GetAll Method In Team Schedule Service");
                return OperationResult<GetAllTeamScheduleResponse>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<GetScheduleTeamResponse>> GetSchedule(int id)
        {
            try
            {
                _logger.LogInformation($"Start GetSchedule Method Ins Team Schedule Service");
                var team = _teamRepository.Find(c => c.Id == id && !c.IsDeleted).FirstOrDefault();

                if (team == null)
                {
                    _logger.LogInformation($"Team with Id : {id} is Null In GetSchedule Method In Team Schedule Service");
                    return OperationResult<GetScheduleTeamResponse>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["TeamNotFound", id].Value);
                }
                var teamSchedule = _teamScheduleRepository.Find(n => (n.AwayTeamId == id || n.HomeTeamId == id) && !n.IsDeleted).Include(h => h.HomeTeam).Include(w => w.AwayTeam).ToList();
                GetScheduleTeamResponse getScheduleTeamResponse = new GetScheduleTeamResponse()
                {
                    Items = _mapper.Map<List<GetScheduleTeamModel>>(teamSchedule)
                };
                return OperationResult<GetScheduleTeamResponse>.Success(getScheduleTeamResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In GetSchedule Method In Team Schedule Service");
                return OperationResult<GetScheduleTeamResponse>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<int>> Add(TeamScheduleRequest teamScheduleRequest)
        {
            try
            {
                _logger.LogInformation($"Start Add Method In Team Schedule Service");
                if(teamScheduleRequest.HomeTeamId == teamScheduleRequest.AwayTeamId)
                {
                    _logger.LogInformation($"Two Team Is Same : {teamScheduleRequest.HomeTeamId}   In Add Method In Team Member Service");
                    return OperationResult<int>.Fail(HttpErrorCode.Conflict, CommonErrorCodes.NOT_FOUND, _localizer["TwoTeamsIsSame", teamScheduleRequest.HomeTeamId].Value);
                }
                TeamSchedule teamScheduleEnitity = _mapper.Map<TeamSchedule>(teamScheduleRequest);
                await _teamScheduleRepository.Add(teamScheduleEnitity);

                return OperationResult<int>.Success(teamScheduleEnitity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Add Method In Team Schedule Service");
                return OperationResult<int>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

    }
}
