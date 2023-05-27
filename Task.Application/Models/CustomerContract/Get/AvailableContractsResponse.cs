using Task.Core.Base;

namespace Task.Application.Models.Contracts.Get
{
    public class AvailableContractsResponse : BaseResponseList<AvailableContractModel>
    {
        public int MaxInitialReservationDate { get; set; }
    }
}
