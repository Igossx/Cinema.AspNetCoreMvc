using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Screening.Queries
{
    public class ScreeningDto
    {
        public int Id { get; set; }

        [Display(Name = "Tytuł filmu")]
        public string MovieTitle { get; set; } = default!;

        [Display(Name = "Nazwa sali")]
        public string CinemaHallName { get; set; } = default!;

        [Display(Name = "Data")]
        public DateTime ScreeningDate { get; set; }

        [Display(Name = "Godzina")]
        public TimeSpan ScreeningTime { get; set; }
    }
}
