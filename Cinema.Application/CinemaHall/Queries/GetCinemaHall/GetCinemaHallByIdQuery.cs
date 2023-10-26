using MediatR;

namespace Cinema.Application.CinemaHall.Queries.GetCinemaHall
{
    public class GetCinemaHallByIdQuery : IRequest<CinemaHallDto>
    {
        public int Id { get; set; }
    }
}
