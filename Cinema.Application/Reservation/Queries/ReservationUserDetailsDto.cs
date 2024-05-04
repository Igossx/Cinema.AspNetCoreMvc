using Cinema.Domain.Enums;

namespace Cinema.Application.Reservation.Queries
{
    public class ReservationUserDetailsDto
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; } = default!;
        public string CinemaHallName { get; set; } = default!;
        public DateTime ScreeningDate { get; set; }
        public TimeSpan ScreeningTime { get; set; }
        public bool IsConfirmed { get; set; }
        public int TotalSeats { get; set; }
        public decimal TotalCost { get; set; }
        public TicketType TicketType { get; set; }
        public bool IsPaidFor { get; set; } = false;
        public string ReservedSeats { get; set; } = default!;
    }
}
