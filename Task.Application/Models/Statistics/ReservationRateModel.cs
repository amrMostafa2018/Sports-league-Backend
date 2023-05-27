using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Enums;

namespace Task.Application.Models.Statistics
{
    public class ReservationRateModel
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }

    public class ReservationRate : ReservationRateModel
    {
        public decimal TotalInitialReservationPayment { get; set; }
    }
}
