using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Domain.Enums
{
    public enum ContractReservationStatus
    {
        Pending, // contract reservation without (accept/reject)
        Accepted, // contract reservation approved from owner but not complete by customer
        Ongoing, // contract reservation completed by customer but in (InitialReservationExpirationDate )
        Completed, // contract reservation completed by customer and spent (InitialReservationExpirationDate )
        Removed, // if contract reservation completed by customer and spent (InitialReservationExpirationDate ) but papers not correct
        Rejected // contract reservation rejected by owner
    }
}
