using MediatR;

namespace Cinema.Application.Reservation.Commands.UpdateIsPaidFor
{
    public class UpdateIsPaidForReservationCommand : UpdateIsPaidForReservationDto, IRequest
    {
        public Guid Id { get; set; }
    }
}
