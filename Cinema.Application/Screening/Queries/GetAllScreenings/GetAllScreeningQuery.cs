using MediatR;

namespace Cinema.Application.Screening.Queries.GetAllScreenings
{
    public class GetAllScreeningsQuery : IRequest<IEnumerable<ScreeningDto>>
    {

    }
}
