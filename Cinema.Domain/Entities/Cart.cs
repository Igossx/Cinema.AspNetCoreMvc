namespace Cinema.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
