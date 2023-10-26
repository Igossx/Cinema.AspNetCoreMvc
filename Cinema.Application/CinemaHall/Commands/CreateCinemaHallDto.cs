namespace Cinema.Application.CinemaHall.Commands
{
    public class CreateCinemaHallDto
    {
        public string Name { get; set; } = default!;
        public int TotalSeats { get; set; }
    }
}
