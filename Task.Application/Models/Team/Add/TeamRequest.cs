using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.Team.Add
{
    public class TeamRequest : IMapFrom<Domain.Entites.Team>
    {
        [Required(ErrorMessage ="Team Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Team City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Team Coach is required")]
        public string Coach { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Team, TeamRequest>().ReverseMap();
        }
    }
}
