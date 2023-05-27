using Task.Application.Models.Team.Get;
using Task.Application.Models.TeamMember.Get;

namespace Task.Application.Models.Team.GetById
{
    public class GetTeamDetailsResponse
    {
        public GetAllTeamModel TeamDetails { get; set; }
        public List<GetAllTeamMemberModel> TeamMembers { get; set; }
    }
}
