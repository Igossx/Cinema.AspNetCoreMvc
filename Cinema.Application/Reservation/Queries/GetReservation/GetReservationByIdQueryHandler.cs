using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.Reservation.Queries.GetReservation
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDetailsDto>
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreeningRepository _screeningRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetReservationByIdQueryHandler(ISeatRepository seatRepository, IReservationRepository reservationRepository,
            IScreeningRepository screeningRepository, UserManager<ApplicationUser> userManager)
        {
            _seatRepository = seatRepository;
            _reservationRepository = reservationRepository;
            _screeningRepository = screeningRepository;
            _userManager = userManager;
        }

        public async Task<ReservationDetailsDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);

            var cinemaHall = screening.CinemaHall;

            var movie = screening.Movie;

            var user = await _userManager.FindByIdAsync(reservation.UserId);

            var reservedSeats = await _seatRepository.GetSeatsFromReservation(request.Id);

            var reservationDto = new ReservationDetailsDto()
            {
                Id = reservation.Id,
                MovieTitle = movie.Title,
                CinemaHallName = cinemaHall.Name,
                ScreeningDate = screening.Date,
                ScreeningTime = screening.Time,
                IsConfirmed = reservation.IsConfirmed,
                UserEmail = user!.Email!,
                TotalSeats = reservation.TotalSeats,
                UserId = reservation.UserId,
                ReservationTime = reservation.ReservationTime,
                TotalCost = reservation.TotalCost,
                TicketType = reservation.TicketType,
                ReservedSeats = reservedSeats
            };

            return reservationDto;
        }
    }
}
