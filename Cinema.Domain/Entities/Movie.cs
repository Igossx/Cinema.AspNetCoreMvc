using Cinema.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinema.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string EncodedTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public string? ImagePath { get; set; } // Ścieżka do pliku graficznego plakatu
        public IFormFile? PosterImage { get; set; } // Przesłany plik graficzny plakatu
        public string TrailerLink { get; set; } = default!;
        public string Director { get; set; } = default!;

        public List<Screening> Screenings { get; set; } = new List<Screening>();

        public void EncodeTitle() => EncodedTitle = Title.ToLower().Replace(" ", "-");
    }
}
