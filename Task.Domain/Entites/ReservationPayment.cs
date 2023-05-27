using Task.Domain.Base;
using Task.Domain.Enums;
using Task.Domain.Lookups;

namespace Task.Domain.Entites
{
    public class ReservationPayment : CreationEntity<int>
    {
        public ReservationPayment()
        {
            ReservationsRevenue = new HashSet<ReservationsRevenue>();
        }
        public int ReservationId { get; set; }
        public Reservations Reservation { get; set; }
        public bool IsCash { get; set; }
        public PaymentGetways PaymentGetway { get; set; }
        public long CardNo { get; set; }
        public string TransactionId { get; set; }
        public DateTime? EndDateOfExpireDate { get; set; }
        public int? BankId { get; set; }
        public Bank Bank { get; set; }
        public ICollection<ReservationsRevenue> ReservationsRevenue { get; set; }

    }
}