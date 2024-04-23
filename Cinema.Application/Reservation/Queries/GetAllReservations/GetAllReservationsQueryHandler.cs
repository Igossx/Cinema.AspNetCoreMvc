using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Queries.GetAllReservations
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreeningRepository _screeningRepository;

        public GetAllReservationsQueryHandler(IReservationRepository reservationRepository,
            IScreeningRepository screeningRepository)
        {
            _reservationRepository = reservationRepository;
            _screeningRepository = screeningRepository;

        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();

            var reservationDtos = new List<ReservationDto>();

            foreach (var reservation in reservations)
            {
                var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);
                var movie = screening.Movie;
                var cinemaHall = screening.CinemaHall;

                var reservationDto = new ReservationDto()
                {
                    Id = reservation.Id,
                    MovieTitle = movie.Title,
                    CinemaHallName = cinemaHall.Name,
                    ScreeningDate = screening.Date,
                    ScreeningTime = screening.Time,
                    TotalCost = reservation.TotalCost
                };

                reservationDtos.Add(reservationDto);
            }

            return reservationDtos;
        }
    }
}
