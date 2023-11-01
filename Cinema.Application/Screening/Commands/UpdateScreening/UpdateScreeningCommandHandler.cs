using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Commands.UpdateScreening
{
    public class UpdateScreeningCommandHandler : IRequestHandler<UpdateScreeningCommand>
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;

        public UpdateScreeningCommandHandler(IScreeningRepository screeningRepository, IMovieRepository movieRepository)
        {
            _screeningRepository = screeningRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(UpdateScreeningCommand request, CancellationToken cancellationToken)
        {
            var screenigToUpdate = await _screeningRepository.GetByIdAsync(request.Id);

            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            screenigToUpdate.MovieId = request.MovieId;
            screenigToUpdate.DateTime = request.DateTime;
            screenigToUpdate.RegularTicketPrice = request.RegularTicketPrice;
            screenigToUpdate.ReducedTicketPrice = request.ReducedTicketPrice;
            screenigToUpdate.EndDateTime = request.DateTime.AddMinutes(movie.Duration);

            await _screeningRepository.Update(screenigToUpdate);

            return Unit.Value;
        }
    }
}
