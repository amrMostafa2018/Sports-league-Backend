using Task.Core.Base;

namespace Task.Application.Models.OwnerRevenueCollection.Get.WithdrawableAmounts
{
    public class WithdrawableAmountsResponse : BaseResponseList<WithdrawableAmountsModel>
    {
        public DateTime? LastProcessDate { get; set; }
        public decimal TotalAmounts { get; set; }
    }
}
