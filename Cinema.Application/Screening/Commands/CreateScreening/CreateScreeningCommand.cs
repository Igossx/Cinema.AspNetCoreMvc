using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Screening.Commands.CreateScreening
{
    public class CreateScreeningCommand : CreateScreeningDto, IRequest
    {
        public SelectList? Movies { set; get; }
        public SelectList? CinemaHalls { set; get; }
    }
}
