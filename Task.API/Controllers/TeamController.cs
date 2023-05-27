using Microsoft.AspNetCore.Mvc;
using Task.Application.Contracts;
using Task.Application.Models.Team.Add;
using Task.Application.Models.Team.Edit;
using Task.Application.Models.Team.Get;
using Task.Application.Models.Team.GetById;
using Task.Shared.API;

namespace Task.API.Controllers
{
    [Route("api/teams/")]
    public class TeamController : ApiControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllTeamsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var respons = await _teamService.GetAll();
            return ProcessResponse(respons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTeamDetailsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var respons = await _teamService.GetById(id);
            return ProcessResponse(respons);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] TeamRequest teamRequest)
        {
            var respons = await _teamService.Add(teamRequest);
            return ProcessResponse(respons);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit([FromBody] EditTeamRequest editTeamRequest)
        {
            var respons = await _teamService.Edit(editTeamRequest);
            return ProcessResponse(respons);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var respons = await _teamService.Delete(id);
            return ProcessResponse(respons);
        }
    }
}
