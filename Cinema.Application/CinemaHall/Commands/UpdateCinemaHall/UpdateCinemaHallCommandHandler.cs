using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.CinemaHall.Commands.DeleteCinemaHall
{
    public class UpdateCinemaHallCommandHandler : IRequestHandler<UpdateCinemaHallCommand>
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public UpdateCinemaHallCommandHandler(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<Unit> Handle(UpdateCinemaHallCommand request, CancellationToken cancellationToken)
        {
            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(request.Id);

            cinemaHall.Name = request.Name;

            await _cinemaHallRepository.Update(cinemaHall);

            return Unit.Value;
        }
    }
}
