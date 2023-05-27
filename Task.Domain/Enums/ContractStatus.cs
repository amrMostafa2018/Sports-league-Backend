using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Domain.Enums
{
    public enum ContractStatus
    {
        Completed = 1,
        Reservation = 2,
        NotReservation = 3,
        Pending = 4,
        Rejected = 5,
        Deleted = 6
    }
}