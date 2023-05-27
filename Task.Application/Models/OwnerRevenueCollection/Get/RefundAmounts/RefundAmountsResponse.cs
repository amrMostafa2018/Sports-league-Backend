using Task.Core.Base;

namespace Task.Application.Models.OwnerRevenueCollection.Get.RefundAmounts
{
    public class RefundAmountsResponse : BaseResponseList<RefundAmountsModel>
    {
        public DateTime? LastProcessDate { get; set; }
        public decimal TotalAmounts { get; set; }

    }
}
