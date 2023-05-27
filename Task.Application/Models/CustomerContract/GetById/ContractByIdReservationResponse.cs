
using Task.Application.Models.Contracts.GetById;

namespace Task.Application.Models.CustomerContract.GetById
{
    public class ContractByIdReservationResponse
    {
        public ContractByIdReservationModel Contract { get; set; }
        public ContractDetailsModel ContractDetails { get; set; }
        public List<string> ContractAttachments { get; set; }
        public ContractByIdDetailsReservationModel ReservationDetails { get; set; }

    }
}
