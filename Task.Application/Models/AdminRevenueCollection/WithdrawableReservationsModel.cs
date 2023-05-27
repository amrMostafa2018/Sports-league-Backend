using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;

namespace Task.Application.Models.AdminRevenueCollection
{
    public class WithdrawableReservationsModel : IMapFrom<Domain.Entites.ReservationPayment>
    {
        public int Id { get; set; }
        public int ReservationNumber { get; set; }
        public int ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public string OwnerName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReservationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ReservationPayment, WithdrawableReservationsModel>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Reservation.Id))
                   .ForMember(d => d.ReservationNumber, opt => opt.MapFrom(s => s.Reservation.ReservationNumber))
                   .ForMember(d => d.ContractNumber, opt => opt.MapFrom(s => s.Reservation.Contract.ContractNumber))
                   .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Reservation.Customer.FullName))

                   .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.Reservation.Contract.ImageUrl) ? HostUrl.BackEnd(s.Reservation.Contract.ImageUrl) : s.Reservation.Contract.ImageUrl))
                   .ForMember(d => d.ReservationDate, opt => opt.MapFrom(s => s.CreationDate))
                   .ReverseMap();
        }
    }
}
