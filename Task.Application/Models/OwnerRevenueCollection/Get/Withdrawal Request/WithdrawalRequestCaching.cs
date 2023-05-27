

namespace Task.Application.Models.OwnerRevenueCollection.Get.Withdrawal_Request
{
    public class WithdrawalRequestCaching
    {
        public Guid Token { get; set; }
        public List<int> ReservationIdsList { get; set; }
        public decimal OwnerAmountDue { get; set; }
        public decimal CustomerAmountDue { get; set; }
        public decimal RevenueAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
