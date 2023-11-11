using MediatR;

namespace Cinema.Application.Movie.Queries.GetThreeRandomMovies
{
    public class GetThreeRandomMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {

    }
}
