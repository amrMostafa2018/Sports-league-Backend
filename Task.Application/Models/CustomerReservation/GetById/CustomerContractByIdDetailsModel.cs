using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerReservation.GetById
{
    public class CustomerContractByIdDetailsModel : IMapFrom<Domain.Entites.Reservations>
    {
        public decimal InitialReservationPayment { get; set; }
        public DateTime CreationDate { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }
        public decimal TotalAmount { get; set; }
        public int InitialReservationExpirationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, CustomerContractByIdDetailsModel>()
                .ForMember(d => d.InitialReservationPayment, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationPayment))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => s.ReservationPayment.CreationDate))
                .ForMember(d => d.ReservationAvailability, opt => opt.MapFrom(s => s.Contract.ReservationAvailability))
                .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.Contract.ContractPayment.TotalAmount))
                .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationExpirationDate));
        }

    }
}
