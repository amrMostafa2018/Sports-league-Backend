using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.OwnerContractRequests.GetById
{
    public class OwnerReservationByIdModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int ReservationNumber { get; set; }
        public ContractReservationStatus Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string MarketerName { get; set; }
        public bool IsCash { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, OwnerReservationByIdModel>()
                .ForMember(d => d.MarketerName, opt => opt.MapFrom(s => s.Marketer.FullName))
                .ForMember(d => d.CustomerPhone, opt => opt.MapFrom(s => s.Customer.PhoneNumber))
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FullName))
                .ForMember(d => d.IsCash, opt => opt.MapFrom(s => s.ReservationPayment.IsCash));
        }
    }
}