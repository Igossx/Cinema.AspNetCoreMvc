using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Commands.UpdateScreening
{
    public class UpdateScreeningCommandHandler : IRequestHandler<UpdateScreeningCommand>
    {
        private readonly IScreeningRepository _screeningRepository;

        public UpdateScreeningCommandHandler(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }

        public async Task<Unit> Handle(UpdateScreeningCommand request, CancellationToken cancellationToken)
        {
            var screenigToUpdate = await _screeningRepository.GetByIdAsync(request.Id);

            screenigToUpdate.MovieId = request.MovieId;
            screenigToUpdate.DateTime = request.DateTime;

            await _screeningRepository.Update(screenigToUpdate);

            return Unit.Value;
        }
    }
}
