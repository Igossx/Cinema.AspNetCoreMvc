using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.CinemaHall.Commands.DeleteCinemaHall
{
    public class DeleteCinemaHallCommandHandler : IRequestHandler<DeleteCinemaHallCommand>
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public DeleteCinemaHallCommandHandler(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<Unit> Handle(DeleteCinemaHallCommand request, CancellationToken cancellationToken)
        {
            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(request.Id);

            await _cinemaHallRepository.Delete(cinemaHall);

            return Unit.Value;
        }
    }
}
