using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.Edit
{
    public class EditContractDetailsRequest : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public int BlockNumber { get; set; }
        public int FloorNumber { get; set; }
        public int BuildingNumber { get; set; }
        public int CityId { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, EditContractDetailsRequest>().ReverseMap();
        }
    }
}
