using Task.Core.Base;

namespace Task.Application.Models.Contracts.Get
{
    public class ContractsResponse : BaseResponseList<ContractModel>
    {
        public int MaxInitialReservationDate { get; set; }
    }
}
