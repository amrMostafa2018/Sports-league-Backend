using Task.Core.Base;

namespace Task.Application.Models.OwnerRevenueCollection.Get.RefundAmounts
{
    public class OwnerRefundAmountsResponse : BaseResponseList<OwnerRefundAmountsModel>
    {
        public DateTime? LastProcessDate { get; set; }
        public decimal TotalAmounts { get; set; }

    }
}
