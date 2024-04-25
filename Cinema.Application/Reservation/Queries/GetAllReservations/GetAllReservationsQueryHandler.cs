using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.Reservation.Queries.GetAllReservations
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreeningRepository _screeningRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllReservationsQueryHandler(IReservationRepository reservationRepository,
            IScreeningRepository screeningRepository,
            UserManager<ApplicationUser> userManager)
        {
            _reservationRepository = reservationRepository;
            _screeningRepository = screeningRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();

            var reservationDtos = new List<ReservationDto>();

            foreach (var reservation in reservations)
            {
                var user = await _userManager.FindByIdAsync(reservation.UserId);
                var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);
                var movie = screening.Movie;
                var cinemaHall = screening.CinemaHall;

                var reservationDto = new ReservationDto()
                {
                    Id = reservation.Id,
                    MovieTitle = movie.Title,
                    IsConfirmed = reservation.IsConfirmed,
                    TotalSeats = reservation.TotalSeats,
                    ReservationTime = reservation.ReservationTime,
                    UserEmail = user!.Email!,
                    TotalCost = reservation.TotalCost
                };

                reservationDtos.Add(reservationDto);
            }

            return reservationDtos;
        }
    }
}
