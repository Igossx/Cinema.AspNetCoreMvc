using Cinema.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinema.Application.Movie.Queries
{
    public class MovieDto
    {
        public string Title { get; set; } = default!;
        public string EncodedTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public string? ImagePath { get; set; } // Ścieżka do pliku graficznego plakatu

    }
}
