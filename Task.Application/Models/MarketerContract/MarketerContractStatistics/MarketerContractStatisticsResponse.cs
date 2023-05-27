using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Models.MarketerContract.MarketerContractStatistics
{
    public class MarketerContractStatisticsResponse
    {
        public int AllContracts { get; set; }
        public int CustomersNumber { get; set; }
        public int ReservedContracts { get; set; }
        public int RemovedContracts { get; set; }
        public int CompletedContracts { get; set; }
 
    }
}
