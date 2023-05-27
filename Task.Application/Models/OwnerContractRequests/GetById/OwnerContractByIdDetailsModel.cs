using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;
using Task.Shared.Enums;

namespace Task.Application.Models.OwnerContractRequests.GetById
{
    public class OwnerContractByIdDetailsModel : IMapFrom<Domain.Entites.Reservations>
    {
        public ContractReservationStatus Status { get; set; }
        public decimal InitialReservationPayment { get; set; }
        public DateTime CreationDate { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }
        public ReservedBy ReservedBy { get; set; }
        public int InitialReservationExpirationDate { get; set; }
        public decimal TotalAmount { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, OwnerContractByIdDetailsModel>()
                .ForMember(d => d.ReservationAvailability, opt => opt.MapFrom(s => s.Contract.ReservationAvailability))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => (s.Status == ContractReservationStatus.Pending || s.Status == ContractReservationStatus.Accepted || s.Status == ContractReservationStatus.Rejected) ? s.CreationDate :  s.ReservationPayment.CreationDate))
                .ForMember(d => d.ReservedBy, opt => opt.MapFrom(s => (string.IsNullOrEmpty(s.MarketerId) ? ReservedBy.Customer : ReservedBy.Marketer)))
                .ForMember(d => d.InitialReservationPayment, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationPayment))
                .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.Contract.ContractPayment.TotalAmount))
                .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationExpirationDate));
        }
    }
}
