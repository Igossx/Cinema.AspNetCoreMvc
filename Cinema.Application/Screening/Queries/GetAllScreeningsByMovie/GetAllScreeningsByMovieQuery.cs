using MediatR;

namespace Cinema.Application.Screening.Queries.GetAllScreeningsByMovie
{
    public class GetAllScreeningsByMovieQuery : IRequest<IEnumerable<ScreeningDto>>
    {
        public int MovieId { get; set; }
    }
}
