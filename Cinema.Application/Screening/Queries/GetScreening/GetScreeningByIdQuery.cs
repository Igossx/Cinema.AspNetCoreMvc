using MediatR;

namespace Cinema.Application.Screening.Queries.GetScreening
{
    public class GetScreeningByIdQuery : IRequest<ScreeningDetailsDto>
    {
        public int Id { get; set; }
    }
}
