using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Queries.GetAllScreeningsByMovie
{
    public class GetAllScreeningsByMovieQueryHandler : IRequestHandler<GetAllScreeningsByMovieQuery, IEnumerable<ScreeningDto>>
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public GetAllScreeningsByMovieQueryHandler(IScreeningRepository screeningRepository,
            IMovieRepository movieRepository, ICinemaHallRepository cinemaHallRepository)
        {
            _screeningRepository = screeningRepository;
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<IEnumerable<ScreeningDto>> Handle(GetAllScreeningsByMovieQuery request, CancellationToken cancellationToken)
        {
            var screenings = await _screeningRepository.GetScreeningsByMovieAsync(request.MovieId);

            var screeningDtos = screenings.Select(s => new ScreeningDto()
            {
                Id = s.Id,
                MovieTitle = _movieRepository.GetByIdAsync(s.MovieId).Result.Title,
                CinemaHallName = _cinemaHallRepository.GetByIdAsync(s.CinemaHallId).Result.Name,
                ScreeningDate = s.Date,
                ScreeningTime = s.Time
            });

            return screeningDtos;

        }
    }
}
