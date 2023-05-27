using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.TeamMember.Add
{
    public class TeamMemberRequest : IMapFrom<Domain.Entites.TeamMemeber>
    {
        [Required(ErrorMessage = "Team Member Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Team Member Position is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Team Member Number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Team is required")]
        public int TeamId { get; set; }
      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.TeamMemeber, TeamMemberRequest>().ReverseMap();
        }
    }
}
