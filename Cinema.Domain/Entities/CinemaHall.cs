namespace Cinema.Domain.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int TotalSeats { get; set; }
    }
}
