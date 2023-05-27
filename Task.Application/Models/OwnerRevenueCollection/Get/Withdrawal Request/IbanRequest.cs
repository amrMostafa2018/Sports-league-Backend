using System.ComponentModel.DataAnnotations;

namespace Task.Application.Models.OwnerRevenueCollection.Get.Withdrawal_Request
{
    public class IbanRequest
    {
        [RegularExpression("^SA\\d{4}[0-9A-Z]{18}$", ErrorMessage = "Invalid Iban")]
        public string Iban { get; set; }
    }
}
