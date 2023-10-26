using MediatR;

namespace Cinema.Application.Movie.Queries.GetMovie
{
    public class GetMovieByIdQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}
