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

        public DateTime EndDateTime { get; set; }

        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; } = default!;

        public decimal RegularTicketPrice { get; set; } = 25;
        public decimal ReducedTicketPrice { get; set; } = 15;

        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
