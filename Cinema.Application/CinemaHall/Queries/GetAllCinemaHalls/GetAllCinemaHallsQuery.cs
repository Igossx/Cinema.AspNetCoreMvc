using MediatR;

namespace Cinema.Application.CinemaHall.Queries.GetAllCinemaHalls
{
    public class GetAllCinemaHallsQuery : IRequest<IEnumerable<CinemaHallDto>>
    {

    }
}
