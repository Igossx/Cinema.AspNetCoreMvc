using MediatR;

namespace Cinema.Application.Movie.Commands.UpdateMovie
{
    public class UpdateMovieCommand : UpdateMovieDto, IRequest
    {
        public int Id { get; set; }
    }
}
