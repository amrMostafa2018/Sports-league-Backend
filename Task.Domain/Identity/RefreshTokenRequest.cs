using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Identity
{
    public class RefreshTokenRequest
    {
        public string TokenValue { get; set; }
        public string RefreshUserToken { get; set; }
        public int UserIdentifier { get; set; }
    }
}
