using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.Get
{
    public class AvailableContractModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string ImageUrl { get; set; }
        public decimal TotalAmount { get; set; }
        public int InitialReservationExpirationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, AvailableContractModel>()
                   .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr))
                   .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Region.NameAr))
                   .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUrl) ? HostUrl.BackEnd(s.ImageUrl) : s.ImageUrl))
                   .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.ContractPayment.TotalAmount))
                   .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationExpirationDate));
        }
    }
}