using AutoMapper;
using Task.Domain.Enums;
using Task.Shared.Enums;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.Contracts.GetById
{
    public class ContractByIdDetailsModel : IMapFrom<Domain.Entites.Contracts>
    {
        public decimal InitialReservationPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MarkterAmount { get; set; }
        public DateTime? CreationDate { get; set; }
        public ReservedBy? ReservedBy { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }
        public int InitialReservationExpirationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractByIdDetailsModel>()
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().CreationDate))
                .ForMember(d => d.InitialReservationPayment, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationPayment))
                .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.ContractPayment.TotalAmount))
                .ForMember(d => d.MarkterAmount, opt => opt.MapFrom(s => s.ContractPayment.MarkterAmount))
                .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationExpirationDate));
        }

    }
}
