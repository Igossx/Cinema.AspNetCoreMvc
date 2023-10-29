using MediatR;

namespace Cinema.Application.Screening.Commands.DeleteScreening
{
    public class DeleteScreeningCommand : IRequest
    {
        public int Id { get; set; }
    }
}
