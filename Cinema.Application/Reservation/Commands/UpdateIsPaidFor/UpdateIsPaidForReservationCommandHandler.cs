using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Commands.UpdateIsPaidFor
{
    public class UpdateIsPaidForReservationCommandHandler : IRequestHandler<UpdateIsPaidForReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateIsPaidForReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(UpdateIsPaidForReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            reservation.IsPaidFor = true;

            await _reservationRepository.Update(reservation);

            return Unit.Value;
        }
    }
}
