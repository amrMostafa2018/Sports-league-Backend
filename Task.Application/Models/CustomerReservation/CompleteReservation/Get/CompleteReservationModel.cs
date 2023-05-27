using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerReservation.CompleteReservation.Get
{
    public class CompleteReservationModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CustomerName { get; set; }
        public int IdNumber { get; set; }
        public decimal InitialReservationPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime ReservationExpirationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, CompleteReservationModel>()
                      .ForMember(d => d.ContractType, opt => opt.MapFrom(s => s.Contract.ContractType))
                      .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Contract.Address))
                      .ForMember(d => d.BlockNumber, opt => opt.MapFrom(s => s.Contract.BlockNumber))
                      .ForMember(d => d.BuildingNumber, opt => opt.MapFrom(s => s.Contract.BuildingNumber))
                      .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.Contract.City.NameAr))
                      .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Contract.Region.NameAr))
                      .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FullName))
                      .ForMember(d => d.IdNumber, opt => opt.MapFrom(s => s.Customer.IdNumber))
                      .ForMember(d => d.InitialReservationPayment, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationPayment))
                      .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.Contract.ContractPayment.TotalAmount))
                      .ForMember(d => d.ReservationExpirationDate, opt => opt.MapFrom(s => DateTime.Now.AddDays(s.Contract.ContractPayment.InitialReservationExpirationDate)));
        }

    }
}
