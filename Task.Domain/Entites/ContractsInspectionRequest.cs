using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class ContractsInspectionRequest : CreationEntity<int>
    {

       [ForeignKey(nameof(Marketer))]
        public string? MarketerId { get; set; }
        public ApplicationUser? Marketer { get; set; }
        public ContractsInspectionRequestStatus Status { get; set; }
        public string? RejectReson { get; set; }
        public bool? OwnerContact { get; set; }
        public bool? CustomerContact { get; set; }
        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }

    }
}
