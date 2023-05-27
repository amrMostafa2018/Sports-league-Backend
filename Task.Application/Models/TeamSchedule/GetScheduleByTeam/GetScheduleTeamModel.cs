using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.TeamSchedule.GetScheduleByTeam
{
    public class GetScheduleTeamModel :  IMapFrom<Domain.Entites.TeamSchedule>
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.TeamSchedule, GetScheduleTeamModel>()
                   .ForMember(d => d.HomeTeam, opt => opt.MapFrom(s => s.HomeTeam.Name))
                   .ForMember(d => d.AwayTeam, opt => opt.MapFrom(s => s.AwayTeam.Name))
                   .ReverseMap();
        }
    }
}
