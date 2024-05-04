namespace Cinema.Application.Reservation.Queries
{
    public class PaymentFormDto
    {
        public Guid ReservationId { get; set; }
        public decimal TotalCost { get; set; }
        public string CardNumber { get; set; } = default!;
        public string CardName { get; set; } = default!;
        public string ExpiryDate { get; set; } = default!;
        public string CvvCode { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
