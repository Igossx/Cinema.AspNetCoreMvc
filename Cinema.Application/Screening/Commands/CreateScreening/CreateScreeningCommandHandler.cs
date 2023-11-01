using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Screening.Commands.CreateScreening
{
    public class CreateScreeningCommandHandler : IRequestHandler<CreateScreeningCommand>
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMovieRepository _movieRepository;

        public CreateScreeningCommandHandler(IScreeningRepository screeningRepository,
            ICinemaHallRepository cinemaHallRepository, ISeatRepository seatRepository, IMovieRepository movieRepository)
        {
            _screeningRepository = screeningRepository;
            _cinemaHallRepository = cinemaHallRepository;
            _seatRepository = seatRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
        {
            var screening = new Domain.Entities.Screening()
            {
                MovieId = request.MovieId,
                CinemaHallId = request.CinemaHallId,
                DateTime = request.DateTime
            };

            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            screening.EndDateTime = request.DateTime.AddMinutes(movie.Duration);

            await _screeningRepository.Create(screening);

            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(request.CinemaHallId);

            await GenerateSeats(cinemaHall.TotalSeats, screening.Id);

            return Unit.Value;
        }

        private async Task GenerateSeats(int totalSeats, int screeningId)
        {
            char currentRowLetter = 'A';

            if (totalSeats == 78)
            {
                for (int row = 1; row < 7; row++)
                {
                    for (int seat = 1; seat < 9; seat++)
                    {
                        var newSeat = new Domain.Entities.Seat()
                        {
                            SeatNumber = seat,
                            RowSign = currentRowLetter,
                            ScreeningId = screeningId
                        };
                        await _seatRepository.Create(newSeat);
                    }
                    currentRowLetter++;
                }

                for (int row = 7; row < 10; row++)
                {
                    for (int seat = 1; seat < 11; seat++)
                    {
                        var newSeat = new Domain.Entities.Seat()
                        {
                            SeatNumber = seat,
                            RowSign = currentRowLetter,
                            ScreeningId = screeningId
                        };
                        await _seatRepository.Create(newSeat);
                    }
                    currentRowLetter++;
                }
            }

            if (totalSeats == 132)
            {
                for (int row = 1; row < 8; row++)
                {
                    for (int seat = 1; seat < 13; seat++)
                    {
                        var newSeat = new Domain.Entities.Seat()
                        {
                            SeatNumber = seat,
                            RowSign = currentRowLetter,
                            ScreeningId = screeningId
                        };
                        await _seatRepository.Create(newSeat);
                    }
                    currentRowLetter++;
                }

                for (int row = 8; row < 11; row++)
                {
                    for (int seat = 1; seat < 17; seat++)
                    {
                        var newSeat = new Domain.Entities.Seat()
                        {
                            SeatNumber = seat,
                            RowSign = currentRowLetter,
                            ScreeningId = screeningId
                        };
                        await _seatRepository.Create(newSeat);
                    }
                    currentRowLetter++;
                }
            }
        }
    }
}
