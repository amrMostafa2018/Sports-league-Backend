using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Application.Models.User
{
    public class UserOTPRequest
    {
        public string MobileNumber { get; set; }
        public string OTP { get; set; }
    }
}
