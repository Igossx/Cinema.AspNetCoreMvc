using Cinema.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinema.Application.Movie.Commands
{
    public class UpdateMovieDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public IFormFile? UpdatePosterImage { get; set; } // Przesłany plik graficzny plakatu
        public string? ImagePath { get; set; } // Ścieżka do pliku graficznego plakatu
        public string TrailerLink { get; set; } = default!;
        public string Director { get; set; } = default!;
    }
}
