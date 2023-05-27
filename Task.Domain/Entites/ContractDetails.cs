using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class ContractDetails : BaseEntity<int>
    {
        public int? MainWings { get; set; }
        public int? Bedrooms { get; set; }
        public int? LivingRooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? Kitchen { get; set; }
        public int? Entries { get; set; }
        public bool? GuardRoom { get; set; }
        public bool? ServerRoom { get; set; }
        public int? Elevators { get; set; }
        public int? Terrace { get; set; }
        public int? Courtyard { get; set; }
        public int? Parking { get; set; }
        public string? Description { get; set; }
        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
    }
}
