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
            var selectedSeats = await _reservationRepository.GetSelectedSeatsAsync(request.SelectedSeats);

            await _seatRepository.ReserveSeat(selectedSeats);

            //decimal totalCost = selectedSeats.Count() * (request.TicketType == TicketType.Normal ? screening.RegularTicketPrice : screening.ReducedTicketPrice);

            // Utworzenie nowego obiektu rezerwacji
            var reservation = new Domain.Entities.Reservation
            {
                ScreeningId = request.ScreeningId,
                TotalCost = 100
            };

            await _reservationRepository.Create(reservation);

            await _seatRepository.AssignToReservation(selectedSeats, reservation.Id);

            return Unit.Value;
        }
    }
}
