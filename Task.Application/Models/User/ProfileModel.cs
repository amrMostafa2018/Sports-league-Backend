using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;

namespace Task.Application.Models.User
{
    public class ProfileModel : IMapFrom<Domain.Entites.ApplicationUser>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int MembershipNo { get; set; }
        public string? IdNumber { get; set; }
        public UserType UserType { get; set; }
        public string? ImageUser { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ApplicationUser, ProfileModel>().ForMember(d => d.ImageUser, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUser) ? HostUrl.BackEnd(s.ImageUser) : s.ImageUser)); ;
        }
    }
}
