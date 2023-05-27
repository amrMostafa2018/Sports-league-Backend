using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;

namespace Task.Application.Models.Lookups.Bank
{
    public class GetAllBankModel : IMapFrom<Domain.Lookups.Bank>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public string PhonNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Lookups.Bank, GetAllBankModel>()
                   .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUrl) ? HostUrl.BackEnd(s.ImageUrl) : s.ImageUrl)).ReverseMap();
        }
    }
}
