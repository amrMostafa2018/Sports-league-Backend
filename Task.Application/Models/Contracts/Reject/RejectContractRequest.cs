using System.ComponentModel.DataAnnotations;


namespace Task.Application.Models.Contracts.Reject
{
    public class RejectContractRequest
    {
        public int ContractId { get; set; }
        [Required(ErrorMessage = "Reject Reason Is Required")]
        public string RejectReason { get; set; }
    }
}
