using MediatR;

namespace Cinema.Application.Reservation.Queries.GetReservationUser
{
    public class GetReservationByIdUserQuery : IRequest<ReservationUserDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
