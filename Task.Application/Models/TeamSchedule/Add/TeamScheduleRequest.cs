using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.TeamSchedule.Add
{
    public class TeamScheduleRequest :  IMapFrom<Domain.Entites.TeamSchedule>
    {
        [Required(ErrorMessage = "Schedule Date is required")]
        public DateTime ScheduleDate { get; set; }
        [Required(ErrorMessage = "Home Team is required")]
        public int HomeTeamId { get; set; }
        [Required(ErrorMessage = "Away Team is required")]
        public int AwayTeamId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.TeamSchedule, TeamScheduleRequest>().ReverseMap();
        }

    }
}
