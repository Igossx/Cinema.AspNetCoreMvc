using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Reservation.Queries
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Tytuł filmu")]
        public string MovieTitle { get; set; } = default!;

        [Display(Name = "Nazwa sali")]
        public string CinemaHallName { get; set; } = default!;

        [Display(Name = "Data")]
        public DateTime ScreeningDate { get; set; }

        [Display(Name = "Godzina")]
        public TimeSpan ScreeningTime { get; set; }

        [Display(Name = "Koszt całkowity")]
        public decimal TotalCost { get; set; }
    }
}
