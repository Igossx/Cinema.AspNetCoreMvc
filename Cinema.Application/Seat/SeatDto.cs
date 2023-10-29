namespace Cinema.Application.Seat
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string RowSign { get; set; } = default!;
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public int? ReservationId { get; set; }
    }
}
