using Microsoft.AspNetCore.Mvc;
using Task.Application.Contracts;
using Task.Application.Models.TeamSchedule.Add;
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

        [HttpGet]
        [ProducesResponseType(typeof(GetScheduleTeamResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var respons = await _teamScheduleService.GetAll();
            return ProcessResponse(respons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetScheduleTeamResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var respons = await _teamScheduleService.GetSchedule(id);
            return ProcessResponse(respons);
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] TeamScheduleRequest teamScheduleRequest)
        {
            var respons = await _teamScheduleService.Add(teamScheduleRequest);
            return ProcessResponse(respons);
        }
    }
}
