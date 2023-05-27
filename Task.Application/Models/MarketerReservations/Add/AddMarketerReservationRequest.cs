using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Models.MarketerReservations.Add
{
    public class AddMarketerReservationRequest
    {
        public int ContractId { get; set; }
        public AddCustomerDataRequest CustomerData { get; set; }
        public List<AddMarketerDataRequest> Marketers { get; set; }
    }

}
