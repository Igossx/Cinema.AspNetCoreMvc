using MediatR;

namespace Cinema.Application.CinemaHall.Commands.DeleteCinemaHall
{
    public class DeleteCinemaHallCommand : IRequest
    {
        public int Id { get; set; }
    }
}
