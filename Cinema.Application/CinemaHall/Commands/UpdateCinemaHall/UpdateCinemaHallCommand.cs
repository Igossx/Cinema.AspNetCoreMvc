using MediatR;

namespace Cinema.Application.CinemaHall.Commands.UpdateCinemaHall
{
    public class UpdateCinemaHallCommand : UpdateCinemaHallDto, IRequest
    {
        public int Id { get; set; }
    }
}
