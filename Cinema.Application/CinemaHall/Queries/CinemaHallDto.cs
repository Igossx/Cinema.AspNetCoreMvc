namespace Cinema.Application.CinemaHall.Queries
{
    public class CinemaHallDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int TotalSeats { get; set; }
    }
}
