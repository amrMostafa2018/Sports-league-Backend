using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Application.Models.TeamMember.Add;

namespace Task.Application.Models.TeamMemeber.Edit
{
    public class EditTeamMemberRequest :TeamMemberRequest ,  IMapFrom<Domain.Entites.TeamMemeber>
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.TeamMemeber, EditTeamMemberRequest>().ReverseMap();
        }
    }
}
