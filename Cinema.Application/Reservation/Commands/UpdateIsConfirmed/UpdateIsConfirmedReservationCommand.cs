using MediatR;

namespace Cinema.Application.Reservation.Commands.UpdateIsConfirmed
{
    public class UpdateIsConfirmedReservationCommand : UpdateIsConfirmedReservationDto, IRequest
    {
        public Guid Id { get; set; }
    }
}
