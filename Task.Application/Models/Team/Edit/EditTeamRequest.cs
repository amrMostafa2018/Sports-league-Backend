using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Application.Models.Team.Add;

namespace Task.Application.Models.Team.Edit
{
    public class EditTeamRequest :TeamRequest ,  IMapFrom<Domain.Entites.Team>
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Team, EditTeamRequest>().ReverseMap();
        }
    }
}
