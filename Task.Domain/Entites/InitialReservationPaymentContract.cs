using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class InitialReservationPaymentContract : BaseEntity<int>
    {
        public ContractType ContractType { get; set; }
        public decimal InitialReservationPayment { get; set; }
    }
}
