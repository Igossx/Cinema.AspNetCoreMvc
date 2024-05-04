using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Queries.GetReservationUser
{
    public class GetReservationByIdUserQueryHandler : IRequestHandler<GetReservationByIdUserQuery, ReservationUserDetailsDto>
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreeningRepository _screeningRepository;

        public GetReservationByIdUserQueryHandler(ISeatRepository seatRepository, IReservationRepository reservationRepository,
            IScreeningRepository screeningRepository)
        {
            _seatRepository = seatRepository;
            _reservationRepository = reservationRepository;
            _screeningRepository = screeningRepository;
        }

        public async Task<ReservationUserDetailsDto> Handle(GetReservationByIdUserQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);

            var cinemaHall = screening.CinemaHall;

            var movie = screening.Movie;

            var reservedSeats = await _seatRepository.GetSeatsFromReservation(request.Id);

            var reservationDto = new ReservationUserDetailsDto()
            {
                Id = reservation.Id,
                MovieTitle = movie.Title,
                CinemaHallName = cinemaHall.Name,
                ScreeningDate = screening.Date,
                ScreeningTime = screening.Time,
                IsConfirmed = reservation.IsConfirmed,
                TotalSeats = reservation.TotalSeats,
                TotalCost = reservation.TotalCost,
                TicketType = reservation.TicketType,
                IsPaidFor = reservation.IsPaidFor,
                ReservedSeats = reservedSeats
            };

            return reservationDto;
        }
    }
}
