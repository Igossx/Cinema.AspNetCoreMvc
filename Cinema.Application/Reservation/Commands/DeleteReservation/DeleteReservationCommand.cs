using MediatR;

namespace Cinema.Application.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
