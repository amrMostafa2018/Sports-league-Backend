using System;
using System.Collections.Generic;
using System.Linq;

namespace Task.Application.Models.FollowUpReservation
{
    public class FollowUpReservationAllResponse
    {
        public List<FollowUpContractsModel> ContractsNotReserved { get; set; }
        public List<FollowUpReservationModel> OngoingReservations { get; set; }
        public List<FollowUpReservationModel> CompletedReservations { get; set; }
        public List<FollowUpReservationModel> RemovedReservations { get; set; }
    }
}
