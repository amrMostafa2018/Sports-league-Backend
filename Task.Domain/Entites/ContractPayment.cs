using Task.Domain.Base;

namespace Task.Domain.Entites
{
    public class ContractPayment : BaseEntity<int>
    {
        public decimal InitialReservationPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MarkterAmount { get; set; }
        public int InitialReservationExpirationDate { get; set; }

        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
    }
}
