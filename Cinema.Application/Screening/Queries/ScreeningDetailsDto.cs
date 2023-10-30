using Cinema.Application.Seat;

namespace Cinema.Application.Screening.Queries
{
    public class ScreeningDetailsDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = default!;
        public int CinemaHallId { get; set; }
        public string CinemaHallName { get; set; } = default!;
        public DateTime ScreeningDateTime { get; set; }
        public DateTime ScreeningDate { get; set; }
        public TimeSpan ScreeningTime { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; } = default!;
        public int FreeSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public int TotalSeats { get; set; }

    }
}
