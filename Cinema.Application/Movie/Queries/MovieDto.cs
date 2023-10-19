using Cinema.Domain.Enums;

namespace Cinema.Application.Movie.Queries
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string EncodedTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public string? ImagePath { get; set; } // Ścieżka do pliku graficznego plakatu

    }
}
