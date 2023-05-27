using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;

namespace Task.Domain.Entites
{
    public class MarketersReservations : BaseEntity<int>
    {
        [ForeignKey("Reservations")]
        public int ReservationsId { get; set; }
        public Reservations Reservations { get; set; }

        [ForeignKey("Marketer")]
        public string MarketerId { get; set; }
        public ApplicationUser Marketer { get; set; }
    }
}
