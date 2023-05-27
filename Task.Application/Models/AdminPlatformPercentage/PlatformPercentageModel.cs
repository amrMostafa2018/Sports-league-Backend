using AutoMapper;
using Task.Domain.Enums;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.AdminPlatformPercentage
{
    public class PlatformPercentageModel : IMapFrom<Domain.Entites.PlatformPercentage>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Percentage { get; set; }
        public UserType UserType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.PlatformPercentage, PlatformPercentageModel>()
                   .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.FullName)).ReverseMap();
        }
    }
}
