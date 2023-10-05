namespace Cinema.Domain.Entities
{
    public class CinemaHall
    {
        public int CinemaHallId { get; set; }
        public string Name { get; set; } = default!;
        public int TotalSeats { get; set; }
    }
}
