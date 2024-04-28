using MediatR;

namespace Cinema.Application.Reservation.Queries.GetAllReservationsUser
{
    public class GetAllReservationsUserQuery : IRequest<IEnumerable<ReservationUserDto>>
    {

    }
}
