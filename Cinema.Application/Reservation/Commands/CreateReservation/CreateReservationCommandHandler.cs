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

        public CreateReservationCommandHandler(IScreeningRepository screeningRepository,
            IReservationRepository reservationRepository, ISeatRepository seatRepository)
        {
            _screeningRepository = screeningRepository;
            _reservationRepository = reservationRepository;
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var screening = await _screeningRepository.GetByIdAsync(request.ScreeningId);

            var selectedSeats = await _reservationRepository.GetSelectedSeatsAsync(request.SelectedSeats);

            decimal totalCost = selectedSeats.Count() * (request.TicketType == TicketType.Normal ? screening.RegularTicketPrice : screening.ReducedTicketPrice);

            // Utworzenie nowego obiektu rezerwacji
            var reservation = new Domain.Entities.Reservation
            {
                ScreeningId = request.ScreeningId,
                UserId = "999", // Do zmiany - na razie jest ustawione na wartość domyślną
                TicketType = request.TicketType,
                ReservedSeats = selectedSeats.ToList(),
                TotalCost = totalCost
            };

            await _reservationRepository.Create(reservation);

            return Unit.Value;
        }
    }
}
