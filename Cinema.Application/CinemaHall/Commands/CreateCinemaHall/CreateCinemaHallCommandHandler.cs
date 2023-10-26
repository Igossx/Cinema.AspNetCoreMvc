using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.CinemaHall.Commands.CreateCinemaHall
{
    public class CreateCinemaHallCommandHandler : IRequestHandler<CreateCinemaHallCommand>
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public CreateCinemaHallCommandHandler(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<Unit> Handle(CreateCinemaHallCommand request, CancellationToken cancellationToken)
        {
            var cinemaHall = new Domain.Entities.CinemaHall()
            {
                Name = request.Name,
                TotalSeats = request.TotalSeats
            };

            await _cinemaHallRepository.Create(cinemaHall);

            return Unit.Value;
        }
    }
}
