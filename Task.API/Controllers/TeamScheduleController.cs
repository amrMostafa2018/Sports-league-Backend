using Microsoft.AspNetCore.Mvc;
using Task.Application.Contracts;
using Task.Application.Models.TeamSchedule.GetScheduleByTeam;
using Task.Shared.API;

namespace Task.API.Controllers
{
    [Route("api/team-schedule/")]
    public class TeamScheduleController : ApiControllerBase
    {
        private readonly ITeamScheduleService _teamScheduleService;
        public TeamScheduleController(ITeamScheduleService teamScheduleService)
        {
            _teamScheduleService = teamScheduleService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetScheduleTeamResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var respons = await _teamScheduleService.GetSchedule(id);
            return ProcessResponse(respons);
        }

    }
}
