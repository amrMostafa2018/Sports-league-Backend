using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.GetById
{
    public class ContractDetailsModel : IMapFrom<Domain.Entites.Contracts>
    {
        public ContractFrontFacade FrontFacade { get; set; }
        public ApartmentType? ApartmentType { get; set; }
        public VillaType? VillaType { get; set; }
        public float Area { get; set; }
        public int? FloorNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public int? MainWings { get; set; }
        public int? Bedrooms { get; set; }
        public int? LivingRooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? Kitchen { get; set; }
        public int? Entries { get; set; }
        public bool? GuardRoom { get; set; }
        public bool? ServerRoom { get; set; }
        public int? Elevators { get; set; }
        public int? Terrace { get; set; }
        public int? Courtyard { get; set; }
        public int? Parking { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractDetailsModel>()
                   .ForMember(d => d.MainWings, opt => opt.MapFrom(s => s.ContractDetails.MainWings))
                   .ForMember(d => d.Bedrooms, opt => opt.MapFrom(s => s.ContractDetails.Bedrooms))
                   .ForMember(d => d.LivingRooms, opt => opt.MapFrom(s => s.ContractDetails.LivingRooms))
                   .ForMember(d => d.Bathrooms, opt => opt.MapFrom(s => s.ContractDetails.Bathrooms))
                   .ForMember(d => d.Kitchen, opt => opt.MapFrom(s => s.ContractDetails.Kitchen))
                   .ForMember(d => d.Entries, opt => opt.MapFrom(s => s.ContractDetails.Entries))
                   .ForMember(d => d.GuardRoom, opt => opt.MapFrom(s => s.ContractDetails.GuardRoom))
                   .ForMember(d => d.ServerRoom, opt => opt.MapFrom(s => s.ContractDetails.ServerRoom))
                   .ForMember(d => d.Elevators, opt => opt.MapFrom(s => s.ContractDetails.Elevators))
                   .ForMember(d => d.Terrace, opt => opt.MapFrom(s => s.ContractDetails.Terrace))
                   .ForMember(d => d.Courtyard, opt => opt.MapFrom(s => s.ContractDetails.Courtyard))
                   .ForMember(d => d.Parking, opt => opt.MapFrom(s => s.ContractDetails.Parking))
                   .ForMember(d => d.Description, opt => opt.MapFrom(s => s.ContractDetails.Description))
                   .ReverseMap();
        }

    }
}
