
using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;

namespace Task.Application.Models.ContractWithMembershipNo.Contract
{
    public class OwnerModel : IMapFrom<Domain.Entites.ApplicationUser>
    {
        public string FullName { get; set; }
        public long MembershipNo { get; set; }
        public string? ImageUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ApplicationUser, OwnerModel>()
                   .ForMember(d => d.ImageUser, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUser) ? HostUrl.BackEnd(s.ImageUser) : s.ImageUser));
        }
    }
}
