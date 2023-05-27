using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerContract.GetById
{
    public class ContractByIdReservationModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractByIdReservationModel>()
                   .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr))
                   .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Region.NameAr))
                   .ReverseMap();
        }

    }
}
