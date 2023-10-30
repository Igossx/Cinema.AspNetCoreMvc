using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Screening.Commands.UpdateScreening
{
    public class UpdateScreeningCommand : UpdateScreeningDto, IRequest
    {
        public int Id { get; set; }
        public SelectList? Movies { set; get; }
        public string CinemaHallName { get; set; } = default!;
    }
}
