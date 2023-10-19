using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Movie.Queries.GetAllMovies
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAllAsync();

            var moviesDtos = movies.Select(m => new MovieDto()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Category = m.Category,
                EncodedTitle = m.EncodedTitle,
                ImagePath = m.ImagePath
            });

            return moviesDtos;
        }
    }
}
