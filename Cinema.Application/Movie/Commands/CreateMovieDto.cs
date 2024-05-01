using Cinema.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinema.Application.Movie.Commands
{
    public class CreateMovieDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public FilmCategory Category { get; set; }
        public IFormFile? PosterImage { get; set; } // Przesłany plik graficzny plakatu
        public string TrailerLink { get; set; } = default!;
        public string Director { get; set; } = default!;
    }
}
