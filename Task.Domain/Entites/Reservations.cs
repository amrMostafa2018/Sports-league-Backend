using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class Reservations : CreationEntity<int>
    {
        public Reservations()
        {
            MarketersReservations = new HashSet<MarketersReservations>();
        }
        public int ReservationNumber { get; set; }
        public int ContractId { get; set; }
        public int IdNumber { get; set; }
        public virtual Contracts Contract { get; set; }


        [ForeignKey(nameof(Marketer))]
        public string? MarketerId { get; set; }
        public virtual ApplicationUser? Marketer { get; set; }


        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

        public bool? IsVisited { get; set; }
        public ContractReservationStatus Status { get; set; }

        public virtual ReservationPayment? ReservationPayment { get; set; }

        public string? RejectReason { get; set; }
        public DateTime? ActionDate { get; set; }

        public ICollection<MarketersReservations> MarketersReservations { get; set; }

    }
}
