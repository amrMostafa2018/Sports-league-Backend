using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;

namespace Task.Application.Models.OwnerHome.Reservation.OnGoingReservation
{
    public class OnGoingReservationsModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public int? BlockNumber { get; set; }
        public int? BuildingNumber { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string? ImageUrl { get; set; }
        public int InitialReservationExpirationDate { get; set; }
        public DateTime? ReservationDate { get; set; }
        public string ContractNumber { get; set; }
        public ContractReservationStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, OnGoingReservationsModel>()
                      .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationExpirationDate))
                      .ForMember(d => d.ReservationDate, opt => opt.MapFrom(s => s.ReservationPayment.CreationDate))
                      .ForMember(d => d.ContractNumber, opt => opt.MapFrom(s => s.Contract.ContractNumber))
                      .ForMember(d => d.ContractType, opt => opt.MapFrom(s => s.Contract.ContractType))
                      .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Contract.Address))
                      .ForMember(d => d.BlockNumber, opt => opt.MapFrom(s => s.Contract.BlockNumber))
                      .ForMember(d => d.BuildingNumber, opt => opt.MapFrom(s => s.Contract.BuildingNumber))
                      .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.Contract.City.NameAr))
                      .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Contract.Region.NameAr))
                      .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.Contract.ImageUrl) ? HostUrl.BackEnd(s.Contract.ImageUrl) : s.Contract.ImageUrl));
        }
    }
}
