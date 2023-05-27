using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Application.Models.Contracts.Add
{
    public class AddContractRequest
    {
        public AddContractDataRequest ContractData { get; set; }
        public AddContractDetailsRequest ContractDetails { get; set; }
        public AddContractPaymentRequest ContractPayment { get; set; }
    }
}
