using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.Lookups.Bank
{
    public class BankModel : IMapFrom<Domain.Lookups.Bank>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Lookups.Bank, BankModel>().ReverseMap();
        }
    }
}
