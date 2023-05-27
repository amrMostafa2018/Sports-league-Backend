using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Application.Models.Contracts.Edit
{
    public class EditContractRequest
    {
        public EditContractDetailsRequest ContractDetails { get; set; }
        public EditContractPaymentRequest ContractPayment { get; set; }

    }
}
