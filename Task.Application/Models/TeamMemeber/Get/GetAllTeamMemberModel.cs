using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.TeamMember.Get
{
    public class GetAllTeamMemberModel : IMapFrom<Domain.Entites.TeamMemeber>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.TeamMemeber, GetAllTeamMemberModel>().ReverseMap();
        }
    }
}
