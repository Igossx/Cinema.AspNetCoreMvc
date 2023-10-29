using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Commands.DeleteScreening
{
    public class DeleteScreeningCommandHandler : IRequestHandler<DeleteScreeningCommand>
    {
        private readonly IScreeningRepository _screeningRepository;

        public DeleteScreeningCommandHandler(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }

        public async Task<Unit> Handle(DeleteScreeningCommand request, CancellationToken cancellationToken)
        {
            var screeningToDelete = await _screeningRepository.GetByIdAsync(request.Id);

            await _screeningRepository.Delete(screeningToDelete);

            return Unit.Value;
        }
    }
}
