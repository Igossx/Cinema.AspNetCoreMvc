using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Movie.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _movieRepository.GetByIdAsync(request.Id);

            await _movieRepository.Delete(movieToDelete);

            return Unit.Value;
        }
    }
}
