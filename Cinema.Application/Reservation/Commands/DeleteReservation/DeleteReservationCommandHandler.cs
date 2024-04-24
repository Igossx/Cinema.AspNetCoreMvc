using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatRepository _seatRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository, ISeatRepository seatRepository)
        {
            _reservationRepository = reservationRepository;
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationToDelete = await _reservationRepository.GetByIdAsync(request.Id);

            await _seatRepository.RemoveFromReservation(request.Id);

            await _reservationRepository.Delete(reservationToDelete);

            return Unit.Value;
        }
    }
}
