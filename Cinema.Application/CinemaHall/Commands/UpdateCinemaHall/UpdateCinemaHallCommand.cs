using MediatR;

namespace Cinema.Application.CinemaHall.Commands.DeleteCinemaHall
{
    public class UpdateCinemaHallCommand : UpdateCinemaHallDto, IRequest
    {
        public int Id { get; set; }
    }
}
