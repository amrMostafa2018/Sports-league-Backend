using Microsoft.AspNetCore.Mvc;
using Task.Application.Contracts;
using Task.Application.Models.TeamMember.Add;
using Task.Application.Models.TeamMemeber.Edit;
using Task.Application.Models.TeamMemeber.Get;
using Task.Shared.API;

namespace Task.API.Controllers
{
    [Route("api/team-member/")]
    public class TeamMemebrController : ApiControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;
        public TeamMemebrController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllTeamMemebrsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int teamId)
        {
            var respons = await _teamMemberService.GetAll(teamId);
            return ProcessResponse(respons);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] TeamMemberRequest teamMemberRequest)
        {
            var respons = await _teamMemberService.Add(teamMemberRequest);
            return ProcessResponse(respons);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit([FromBody] EditTeamMemberRequest editTeamMemberReques)
        {
            var respons = await _teamMemberService.Edit(editTeamMemberReques);
            return ProcessResponse(respons);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var respons = await _teamMemberService.Delete(id);
            return ProcessResponse(respons);
        }
    }
}
