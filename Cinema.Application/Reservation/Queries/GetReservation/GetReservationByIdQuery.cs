using MediatR;

namespace Cinema.Application.Reservation.Queries.GetReservation
{
    public class GetReservationByIdQuery : IRequest<ReservationDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
