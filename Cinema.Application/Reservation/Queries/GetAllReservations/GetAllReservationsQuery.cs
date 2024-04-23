using MediatR;

namespace Cinema.Application.Reservation.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>>
    {

    }
}
