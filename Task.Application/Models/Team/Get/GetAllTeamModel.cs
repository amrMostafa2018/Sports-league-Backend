using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.Team.Get
{
    public class GetAllTeamModel : IMapFrom<Domain.Entites.Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Team, GetAllTeamModel>().ReverseMap();
        }
    }
}
