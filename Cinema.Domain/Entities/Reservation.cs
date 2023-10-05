namespace Cinema.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = default!;
        //public string UserId { get; set; }
        public DateTime ReservationTime { get; set; }

        public List<Seat> ReservedSeats { get; set; } = new List<Seat>();

        public decimal TotalCost { get; set; } = 0;
    }
}
