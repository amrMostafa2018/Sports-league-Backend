using Task.Core.Base;

namespace Task.Application.Models.OwnerRevenueCollection.Get.DrawdownsAmounts
{
    public class DrawdownsAmountsResponse : BaseResponseList<DrawdownsAmountsModel>
    {
        public DateTime? LastProcessDate { get; set; }
        public decimal TotalAmounts { get; set; }
    }
}
