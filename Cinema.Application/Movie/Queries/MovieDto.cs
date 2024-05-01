using Cinema.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Movie.Queries
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; } = default!;

        [Display(Name = "Enkodowany tytuł")]
        public string EncodedTitle { get; set; } = default!;

        [Display(Name = "Opis")]
        public string Description { get; set; } = default!;

        [Display(Name = "Data wydania")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Czas trwania")]
        public int Duration { get; set; }

        [Display(Name = "Kategoria")]
        public FilmCategory Category { get; set; }
        public string? ImagePath { get; set; }

        [Display(Name = "Reżyser")]
        public string Director { get; set; } = default!;

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; } = default!;

    }
}
