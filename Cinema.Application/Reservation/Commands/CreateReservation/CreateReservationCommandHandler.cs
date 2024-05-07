using Cinema.Domain.Enums;
using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IUserContext _userContext;

        public CreateReservationCommandHandler(IScreeningRepository screeningRepository,
            IReservationRepository reservationRepository, ISeatRepository seatRepository, IUserContext userContext)
        {
            _screeningRepository = screeningRepository;
            _reservationRepository = reservationRepository;
            _seatRepository = seatRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var currentUser = _userContext.GetCurrentUser();

            if (currentUser == null)
            {
                return Unit.Value;
            }

            var screening = await _screeningRepository.GetByIdAsync(request.ScreeningId);

            var selectedSeats = await _reservationRepository.GetSelectedSeatsAsync(request.SelectedSeats);

            var selectedSeatsString = await _seatRepository.GetStringFromSeats(selectedSeats);

            var numberOfSelectedSeats = selectedSeats.Count();

            await _seatRepository.ReserveSeat(selectedSeats);

            decimal totalCost = selectedSeats.Count() * (request.TicketType == TicketType.Normal ? screening.RegularTicketPrice : screening.ReducedTicketPrice);

            var reservation = new Domain.Entities.Reservation
            {
                ScreeningId = request.ScreeningId,
                TotalCost = totalCost,
                TicketType = request.TicketType,
                TotalSeats = numberOfSelectedSeats,
                UserId = currentUser.Id,
                Seats = selectedSeatsString
            };

            await _reservationRepository.Create(reservation);

            await _seatRepository.AssignToReservation(selectedSeats, reservation.Id);

            return Unit.Value;
        }
    }
}
