using Task.Application.Models.Contracts.GetById;

namespace Task.Application.Models.OwnerContractRequests.GetById
{
    public class OwnerReservationByIdResponse
    {
        public OwnerContractByIdModel Contract { get; set; }
        public ContractDetailsModel ContractDetails { get; set; }
        public List<string> ContractAttachments { get; set; }
        public OwnerReservationByIdModel Reservation { get; set; }
        public OwnerContractByIdDetailsModel ReservationDetails { get; set; }
        public List<MarketerReservationModel> marketerReservationData { get; set; }

    }
}
