using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.GetById
{
    public class ContractReservationModel : IMapFrom<Domain.Entites.Contracts>
    {
        public ContractStatus Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string MarketerName { get; set; }
        public bool? IsCash { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, ContractReservationModel>()
                .ForMember(d => d.MarketerName, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().Marketer.FullName))
                .ForMember(d => d.CustomerPhone, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().Customer.PhoneNumber))
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().Customer.FullName))
                .ForMember(d => d.IsCash, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().ReservationPayment.IsCash));

        }

    }
}
