using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.CinemaHall.Queries.GetCinemaHall
{
    public class GetCinemaHallByIdQueryHandler : IRequestHandler<GetCinemaHallByIdQuery, CinemaHallDto>
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public GetCinemaHallByIdQueryHandler(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<CinemaHallDto> Handle(GetCinemaHallByIdQuery request, CancellationToken cancellationToken)
        {
            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(request.Id);

            var cinemaHallDto = new CinemaHallDto()
            {
                Id = cinemaHall.Id,
                Name = cinemaHall.Name,
                TotalSeats = cinemaHall.TotalSeats
            };

            return cinemaHallDto;
        }
    }
}
