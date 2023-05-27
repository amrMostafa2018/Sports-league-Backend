using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Models.User.Edit
{
    public class UpdatePhoneUserModel
    {
        public string NewPhoneNumber { get; set; }
        public string OldPhoneNumber { get; set; }
        public string Otp { get; set; }
    }
}
