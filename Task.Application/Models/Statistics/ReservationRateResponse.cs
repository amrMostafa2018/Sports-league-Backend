using Task.Core.Base;

namespace Task.Application.Models.Statistics
{
    public class ReservationRateResponse : BaseResponseList<ReservationRateModel>
    {
        public decimal TotalPaymentCurrentMonth { get; set; }
        public decimal Percentage { get; set; }
        public bool IsIncrease { get; set; }
    }
}
