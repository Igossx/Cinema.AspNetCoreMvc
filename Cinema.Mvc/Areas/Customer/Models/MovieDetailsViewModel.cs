using Cinema.Application.Movie.Queries;

namespace Cinema.Mvc.Areas.Customer.Models
{
    public class MovieDetailsViewModel
    {
        public MovieDto? Movie { get; set; }
        public IEnumerable<MovieDto>? RandomMovies { get; set; }
    }
}
