using Cinema.Domain.Enums;

namespace Cinema.Application.Reservation.Queries
{
    public class ReservationUserDto
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; } = default!;
        public bool IsPaidFor { get; set; } = false;
        public TicketType TicketType { get; set; }
        public int TotalSeats { get; set; }
        public decimal TotalCost { get; set; }
    }
}
