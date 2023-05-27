using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Entites;

namespace Task.Application.Models.Contracts.GetById
{
    public class ContractByIdResponse
    {
        public ContractByIdModel Contract { get; set; }
        public ContractDetailsModel ContractDetails  { get; set; }
        public List<string> ContractAttachments { get; set; }
        public ContractReservationModel Reservation { get; set; }
        public ContractByIdDetailsModel ReservationDetails { get; set; }

    }
}
