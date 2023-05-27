using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerReservation.GetById
{
    public class CustomerReservationByIdModel : IMapFrom<Domain.Entites.Reservations>
    {
        public ContractReservationStatus Status { get; set; }
        public string MarketerName { get; set; }
        public bool IsCash { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, CustomerReservationByIdModel>()
                .ForMember(d => d.MarketerName, opt => opt.MapFrom(s => s.Marketer.FullName))
                .ForMember(d => d.IsCash, opt => opt.MapFrom(s => s.ReservationPayment.IsCash));
        }
    }
}
