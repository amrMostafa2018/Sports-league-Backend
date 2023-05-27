

namespace Task.Application.Models.ContractWithMembershipNo.Contract
{
    public class ContractWithMembershipResponse 
    {
        public OwnerModel Owner { get; set; }
        public List<ContractWithMembershipNoModel> Contracts { get; set; }
        public int MaxInitialReservationDate { get; set; }
    }
}
