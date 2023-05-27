using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Models.OwnerHome.ContractStatistics
{
    public class ContractStatisticsResponse
    {
       public int AllContracts { get; set; }
       public int RemovedContracts { get; set; }
       public int CompletedContracts { get; set; }
       public int AvaliableContracts { get; set; }
       public int ReservedContracts { get; set; }
    }
}
