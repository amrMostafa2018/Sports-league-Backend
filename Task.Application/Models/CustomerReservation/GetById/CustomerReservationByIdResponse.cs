using Task.Application.Models.Contracts.GetById;
using Task.Application.Models.OwnerContractRequests.GetById;

namespace Task.Application.Models.CustomerReservation.GetById
{
    public class CustomerReservationByIdResponse
    {
        public CustomerContractByIdModel Contract { get; set; }
        public ContractDetailsModel ContractDetails { get; set; }
        public List<string> ContractAttachments { get; set; }
        public CustomerReservationByIdModel Reservation { get; set; }
        public CustomerContractByIdDetailsModel ReservationDetails { get; set; }
        public List<MarketerReservationModel> marketerReservationData { get; set; }
    }
}
