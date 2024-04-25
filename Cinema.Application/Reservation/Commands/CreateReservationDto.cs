using Cinema.Domain.Enums;

namespace Cinema.Application.Reservation.Commands
{
    public class CreateReservationDto
    {
        public int ScreeningId { get; set; }

        public string UserId { get; set; } = default!;

        public DateTime ReservationTime { get; set; } = DateTime.UtcNow;

        public IEnumerable<int> SelectedSeats { get; set; } = default!;

        public decimal TotalCost { get; set; } = 0;
        public bool IsConfirmed { get; set; } = false;

        public TicketType TicketType { get; set; }

        public bool IsPaidFor { get; set; } = false;
    }
}
