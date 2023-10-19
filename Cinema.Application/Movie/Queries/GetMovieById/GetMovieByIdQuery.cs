using MediatR;

namespace Cinema.Application.Movie.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<MovieDto>
    {
        public int Id { get; set; } = default!;
    }
}
