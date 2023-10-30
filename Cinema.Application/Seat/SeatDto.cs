namespace Cinema.Application.Seat
{
    public class SeatDto
    {
        public char RowSign { get; set; } = default!;
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
    }
}
