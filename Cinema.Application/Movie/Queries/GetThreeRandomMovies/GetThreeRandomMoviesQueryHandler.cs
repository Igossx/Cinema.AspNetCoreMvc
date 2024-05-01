using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Movie.Queries.GetThreeRandomMovies
{
    public class GetThreeRandomMoviesQueryHandler : IRequestHandler<GetThreeRandomMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetThreeRandomMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetThreeRandomMoviesQuery request, CancellationToken cancellationToken)
        {
            var randomMovies = await _movieRepository.GetThreeRandomMoviesAsync();

            var randomMoviesDtos = randomMovies.Select(m => new MovieDto()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Category = m.Category,
                EncodedTitle = m.EncodedTitle,
                ImagePath = m.ImagePath,
                Director = m.Director,
                TrailerLink = m.TrailerLink
            });

            return randomMoviesDtos;
        }
    }
}
