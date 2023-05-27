using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.Add
{
    public class AddContractDataRequest : IMapFrom<Domain.Entites.Contracts>
    {
        public int ContractNumber { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public int? BlockNumber { get; set; }
        public int? BuildingNumber { get; set; }
        public int? FloorNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public ContractFrontFacade FrontFacade { get; set; }
        public ApartmentType? ApartmentType { get; set; }
        public VillaType? VillaType { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }
        public ContactMethod? ContactMethod { get; set; }
        public int? CityId { get; set; }
        public int RegionId { get; set; }
        public float Area { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, AddContractDataRequest>().ReverseMap();
        }
    }
}

