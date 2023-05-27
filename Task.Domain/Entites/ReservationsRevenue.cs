using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class ReservationsRevenue : CreationEntity<int>
    {
        [ForeignKey("ReservationPayment")]
        public int ReservationPaymentId { get; set; }
        public ReservationPayment ReservationPayment { get; set; }

        [ForeignKey("RevenueCollection")]
        public int RevenueCollectionId { get; set; }
        public RevenueCollection RevenueCollection { get; set; }
        public RevenueStatus Status { get; set; }

    }
}