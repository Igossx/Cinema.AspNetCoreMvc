using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.CinemaHall.Queries.GetAllCinemaHalls
{
    public class GetAllCinemaHallsQueryHandler : IRequestHandler<GetAllCinemaHallsQuery, IEnumerable<CinemaHallDto>>
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public GetAllCinemaHallsQueryHandler(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<IEnumerable<CinemaHallDto>> Handle(GetAllCinemaHallsQuery request, CancellationToken cancellationToken)
        {
            var cinemaHalls = await _cinemaHallRepository.GetAllAsync();

            var cinemaHallsDtos = cinemaHalls.Select(c => new CinemaHallDto()
            {
                Id = c.Id,
                Name = c.Name,
                TotalSeats = c.TotalSeats
            });

            return cinemaHallsDtos;
        }
    }
}
