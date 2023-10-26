using MediatR;

namespace Cinema.Application.Movie.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; }
    }
}
