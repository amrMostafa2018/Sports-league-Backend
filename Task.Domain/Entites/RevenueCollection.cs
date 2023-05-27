using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class RevenueCollection : CreationEntity<int>
    {
        public RevenueCollection()
        {
            ReservationsRevenue = new HashSet<ReservationsRevenue>();
        }
        public long RequestNo { get; set; }
        public string Iban { get; set; }
        public string TransactionId { get; set; }
        public PaymentGetways PaymentGetway { get; set; }
        public decimal TotalAmount { get; set; } // المبلغ الاجمالى
        public decimal OwnerAmountDue { get; set; } // المبلغ المستحق للمالك
        public decimal CustomerAmountDue { get; set; } // المبلغ المستحق للعميل
        public decimal RevenueAmount { get; set; } // نسبة المنصه
        public RevenueStatus Status { get; set; }
        public string? RejectReason { get; set; }
        public DateTime? ActionDate { get; set; }
        public ICollection<ReservationsRevenue> ReservationsRevenue { get; set; }

    }
}