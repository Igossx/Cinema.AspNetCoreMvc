using Cinema.Application.Interfaces;
using Cinema.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<SelectList> GetMoviesSelectListAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return new SelectList(movies,
                nameof(Domain.Entities.Movie.Id), nameof(Domain.Entities.Movie.Title));
        }
    }
}
