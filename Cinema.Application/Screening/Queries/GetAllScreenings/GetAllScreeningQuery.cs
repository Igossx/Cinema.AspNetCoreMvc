using MediatR;

namespace Cinema.Application.Screening.Queries.GetAllScreenings
{
    public class GetAllScreeningQuery : IRequest<IEnumerable<ScreeningDto>>
    {

    }
}
