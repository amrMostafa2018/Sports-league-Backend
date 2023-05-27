
namespace Task.Application.Models.CustomerReservation.CompleteReservation.Add
{
    public class CompleteReservationResponse
    {
        public int ReservationNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int RemainingDays { get; set; }
    }
}
