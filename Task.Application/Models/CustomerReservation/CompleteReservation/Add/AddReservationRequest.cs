
using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Application.Models.Contracts.GetById;
using Task.Domain.Enums;

namespace Task.Application.Models.CustomerReservation.CompleteReservation.Add
{
    public class AddReservationRequest : IMapFrom<Domain.Entites.ReservationPayment>
    {
        public int ReservationId { get; set; }
        public int IdNumber { get; set; }
        public bool IsCash { get; set; }
        public int? BankId { get; set; }
        public PaymentGetways PaymentGetway { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ReservationPayment, AddReservationRequest>().ReverseMap();
        }
    }
}
