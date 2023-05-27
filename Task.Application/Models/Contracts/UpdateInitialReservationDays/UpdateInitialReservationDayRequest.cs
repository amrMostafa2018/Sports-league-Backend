using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Models.Contracts.UpdateInitialReservationDays
{
    public class UpdateInitialReservationDayRequest
    {
        public int ContractId { get; set; }
        public int Days { get; set; }
    }
}
