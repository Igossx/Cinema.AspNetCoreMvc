using MediatR;

namespace Cinema.Application.Movie.Queries.GetFourRandomMovies
{
    public class GetFourRandomMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {

    }
}
