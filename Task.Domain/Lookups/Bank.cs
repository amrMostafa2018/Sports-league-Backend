using System.Runtime.InteropServices;
using Task.Domain.Base;
using Task.Domain.Entites;

namespace Task.Domain.Lookups
{
    public class Bank : BaseLookup
    {
        public Bank()
        {
            ReservationsPayment = new HashSet<ReservationPayment>();
        }
        public string? CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public string PhonNumber { get; set; }
        public ICollection<ReservationPayment> ReservationsPayment { get; set; }

    }
}
