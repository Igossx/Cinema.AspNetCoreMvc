using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Reservation.Queries
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Tytuł filmu")]
        public string MovieTitle { get; set; } = default!;

        [Display(Name = "Potwierdzona")]
        public bool IsConfirmed { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; } = default!;

        [Display(Name = "Liczba miejsc")]
        public int TotalSeats { get; set; }

        [Display(Name = "Utworzono")]
        public DateTime ReservationTime { get; set; }

        [Display(Name = "Koszt całkowity")]
        public decimal TotalCost { get; set; }
    }
}
