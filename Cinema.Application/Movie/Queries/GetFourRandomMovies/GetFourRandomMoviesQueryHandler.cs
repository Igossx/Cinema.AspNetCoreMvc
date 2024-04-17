using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Movie.Queries.GetFourRandomMovies
{
    public class GetFourRandomMoviesQueryHandler : IRequestHandler<GetFourRandomMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetFourRandomMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetFourRandomMoviesQuery request, CancellationToken cancellationToken)
        {
            var randomMovies = await _movieRepository.GetFourRandomMoviesAsync();

            var randomMoviesDtos = randomMovies.Select(m => new MovieDto()
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

            return randomMoviesDtos;
        }
    }
}
