using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;

namespace Task.Application.Models.User.Get
{
    public class GetProfileUpdateDataResponse : IMapFrom<Domain.Entites.ApplicationUser>
    {
        public string Id { get; set; }
        public string ImageUser { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ApplicationUser, GetProfileUpdateDataResponse>()
                .ForMember(d => d.ImageUser, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUser) ? HostUrl.BackEnd(s.ImageUser) : s.ImageUser)).ReverseMap();
        }
    }
}
