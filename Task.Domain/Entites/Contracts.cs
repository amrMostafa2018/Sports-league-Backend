using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;
using Task.Domain.Enums;
using Task.Domain.Lookups;

namespace Task.Domain.Entites
{
    public class Contracts : AuditEntityWithSoftDelete<int>
    {
        public Contracts()
        {
            ContractAttachments = new HashSet<ContractAttachment>();
            ContractsInspectionRequests = new HashSet<ContractsInspectionRequest>();
        }

        public int ContractNumber { get; set; }
        public ContractType ContractType { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public int? BlockNumber { get; set; }
        public int? BuildingNumber { get; set; }
        public int? FloorNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public ContractFrontFacade FrontFacade { get; set; }
        public ApartmentType? ApartmentType { get; set; }
        public VillaType? VillaType { get; set; }
        public float Area { get; set; }
        public ReservationAvailabilities ReservationAvailability { get; set; }
        public ContactMethod? ContactMethod { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ActionDate { get; set; }

        [ForeignKey("ActionBy")]
        public string? ActionById { get; set; }
        public ApplicationUser? ActionBy { get; set; }
        public ContractStatus Status { get; set; }
        public string? ImageUrl { get; set; }
        public int ViewCount { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public int? CityId { get; set; }
        public string? RejectReason { get; set; }
        public virtual ContractPayment ContractPayment { get; set; }
        public virtual ContractDetails ContractDetails { get; set; }
        public virtual City? City { get; set; }
        public virtual Region Region { get; set; }
        public ICollection<ContractAttachment> ContractAttachments { get; set; }
        public ICollection<Reservations> Reservations { get; set; }
        public ICollection<ContractsInspectionRequest> ContractsInspectionRequests { get; set; }

    }
}
