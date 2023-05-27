using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;
using Task.Shared.Enums;

namespace Task.Application.Models.OwnerContractRequests.Get
{
    public class OwnerReservationModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int Id { get; set; }
        public int ReservationNumber { get; set; }
        public int ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal InitialAmount { get; set; }
        public string ImageUrl { get; set; }
        public ReservedBy ReservedBy { get; set; }
        public ContractReservationStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, OwnerReservationModel>()
                                        .ForMember(d => d.ContractNumber, opt => opt.MapFrom(s => s.Contract.ContractNumber))
                                        .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FullName))
                                        .ForMember(d => d.ReservedBy, opt => opt.MapFrom(s => (string.IsNullOrEmpty(s.MarketerId) ? Task.Shared.Enums.ReservedBy.Customer : Task.Shared.Enums.ReservedBy.Marketer)))
                                        .ForMember(d => d.InitialAmount, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationPayment))
                                        .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.Contract.ImageUrl) ? HostUrl.BackEnd(s.Contract.ImageUrl) : s.Contract.ImageUrl))
                                        .ReverseMap();
        }

    }
}
