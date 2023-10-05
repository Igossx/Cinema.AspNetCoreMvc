namespace Cinema.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        //public int UserId { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
