using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Commands.UpdateIsConfirmed
{
    public class UpdateIsConfirmedReservationCommandHandler : IRequestHandler<UpdateIsConfirmedReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateIsConfirmedReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(UpdateIsConfirmedReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            reservation.IsConfirmed = true;

            await _reservationRepository.Update(reservation);

            return Unit.Value;
        }
    }
}
