namespace Cinema.Domain.Entities
{
    public class Seat
    {
        public int Id { get; set; }

        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = default!;

        public char RowSign { get; set; } = default!;
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; } = false;

        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; } = default!;
    }
}
