using Cinema.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public string? ImagePath { get; set; } // Ścieżka do pliku graficznego plakatu

        public IFormFile? PosterImage { get; set; } // Przesłany plik graficzny plakatu

        public List<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
