using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.CinemaHall.Queries
{
    public class CinemaHallDto
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; } = default!;

        [Display(Name = "Liczba miejsc")]
        public int TotalSeats { get; set; }
    }
}
