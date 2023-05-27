using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerReservation.GetById
{
    public class CustomerContractByIdModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, CustomerContractByIdModel>()
                   .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr))
                   .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Region.NameAr))
                   .ReverseMap();

        }
    }
}
