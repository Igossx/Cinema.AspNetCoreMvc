using MediatR;

namespace Cinema.Application.Movie.Queries.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {

    }
}
