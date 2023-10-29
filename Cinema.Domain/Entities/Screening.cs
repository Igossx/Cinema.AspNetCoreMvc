using Cinema.Domain.Options;

namespace Cinema.Domain.Entities
{
    public class Screening
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = default!;

        public DateTime DateTime { get; set; }

        public DateTime Date => DateTime.Date;
        public TimeSpan Time => DateTime.TimeOfDay;

        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; } = default!;

        public PricingOptions Pricing { get; set; } = new PricingOptions();

        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
