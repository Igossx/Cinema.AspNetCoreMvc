namespace Cinema.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = default!;

        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

        public DateTime ReservationTime { get; set; } = DateTime.UtcNow;

        public List<Seat> ReservedSeats { get; set; } = new List<Seat>();

        public decimal TotalCost { get; set; } = 0;
        public bool IsConfirmed { get; set; } = false;
    }
}
