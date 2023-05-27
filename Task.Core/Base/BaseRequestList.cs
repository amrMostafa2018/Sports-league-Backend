using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Core.Base
{
    public class BaseRequestList
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = -1;
    }
}
