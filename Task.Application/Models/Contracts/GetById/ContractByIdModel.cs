using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.GetById
{
    public class ContractByIdModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public string CityName { get; set; }
        public string RegoinName { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }
        public bool? IsApproved { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractByIdModel>()
                .ForMember(d => d.IsUsed, opt => opt.MapFrom(s => s.Reservations.Count > 0))
                .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr))
                .ForMember(d => d.RegoinName, opt => opt.MapFrom(s => s.Region.NameAr))
                .ReverseMap();
        }

    }
}
