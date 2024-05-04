using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Queries.GetAllReservationsUser
{
    public class GetAllReservationUserQueryHandler : IRequestHandler<GetAllReservationsUserQuery, IEnumerable<ReservationUserDto>>
    {

        private readonly IUserContext _userContext;
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreeningRepository _screeningRepository;

        public GetAllReservationUserQueryHandler(IUserContext userContext, IReservationRepository reservationRepository,
            IScreeningRepository screeningRepository)
        {
            _userContext = userContext;
            _reservationRepository = reservationRepository;
            _screeningRepository = screeningRepository;
        }

        public async Task<IEnumerable<ReservationUserDto>> Handle(GetAllReservationsUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            var reservations = await _reservationRepository.GetAllReservationsForUser(currentUser!.Id);

            var reservationDtos = new List<ReservationUserDto>();

            foreach (var reservation in reservations)
            {
                var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);
                var movie = screening.Movie;

                var reservationUserDto = new ReservationUserDto()
                {
                    Id = reservation.Id,
                    MovieTitle = movie.Title,
                    TotalSeats = reservation.TotalSeats,
                    TicketType = reservation.TicketType,
                    IsPaidFor = reservation.IsPaidFor,
                    TotalCost = reservation.TotalCost,
                    IsConfirmed = reservation.IsConfirmed
                };

                reservationDtos.Add(reservationUserDto);
            }

            return reservationDtos;
        }
    }
}
