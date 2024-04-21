using Cinema.Application.Seat;
using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Queries.GetScreening
{
    public class GetScreeningByIdQueryHandler : IRequestHandler<GetScreeningByIdQuery, ScreeningDetailsDto>
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISeatRepository _seatRepository;

        public GetScreeningByIdQueryHandler(IScreeningRepository screeningRepository, ICinemaHallRepository cinemaHallRepository,
            IMovieRepository movieRepository, ISeatRepository seatRepository)
        {
            _screeningRepository = screeningRepository;
            _cinemaHallRepository = cinemaHallRepository;
            _movieRepository = movieRepository;
            _seatRepository = seatRepository;
        }

        public async Task<ScreeningDetailsDto> Handle(GetScreeningByIdQuery request, CancellationToken cancellationToken)
        {
            var screening = await _screeningRepository.GetByIdAsync(request.Id);

            var seats = await _seatRepository.GetSeatsByScreeningAsync(request.Id);

            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(screening.CinemaHallId);

            var movie = await _movieRepository.GetByIdAsync(screening.MovieId);

            int freeSeats = seats.Count(s => s.IsReserved == false);
            int occupiedSeats = seats.Count(s => s.IsReserved == true);
            int totalSeats = seats.Count();

            var seatsDto = seats.Select(s => new SeatDto()
            {
                Id = s.Id,
                RowSign = s.RowSign,
                SeatNumber = s.SeatNumber,
                IsReserved = s.IsReserved
            });

            var screeningDto = new ScreeningDetailsDto()
            {
                Id = screening.Id,
                MovieId = screening.MovieId,
                MovieTitle = movie.Title,
                CinemaHallName = cinemaHall.Name,
                CinemaHallId = screening.CinemaHallId,
                ScreeningDateTime = screening.DateTime,
                ScreeningDate = screening.Date,
                ScreeningTime = screening.Time,
                Seats = seatsDto,
                FreeSeats = freeSeats,
                OccupiedSeats = occupiedSeats,
                TotalSeats = totalSeats,
                RegularTicketPrice = screening.RegularTicketPrice,
                ReducedTicketPrice = screening.ReducedTicketPrice,
                ScreeningEndTime = screening.EndDateTime.TimeOfDay
            };

            return screeningDto;
        }
    }
}
