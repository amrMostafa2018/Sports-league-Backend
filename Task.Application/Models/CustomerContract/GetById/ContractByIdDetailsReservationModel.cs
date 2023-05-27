using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Entites;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerContract.GetById
{
    public class ContractByIdDetailsReservationModel : IMapFrom<Domain.Entites.Contracts>
    {
        public decimal InitialReservationPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public int InitialReservationExpirationDate { get; set; }
        public bool IsSendReservation { get; set; }
        public bool IsSendInspection { get; set; }
        public ContractsInspectionRequestStatus? InspectionRequestStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractByIdDetailsReservationModel>()
                   .ForMember(d => d.InitialReservationPayment, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationPayment))
                   .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.ContractPayment.TotalAmount))
                   .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationExpirationDate))
                   .ForMember(d => d.IsSendReservation, opt => opt.MapFrom(s => s.Reservations.Count > 0))
                   .ForMember(d => d.IsSendInspection, opt => opt.MapFrom(s => s.ContractsInspectionRequests.Count > 0));
        }

    }
}
