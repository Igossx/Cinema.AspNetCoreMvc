using Cinema.Domain.Interfaces;
using FluentValidation;

namespace Cinema.Application.Screening.Commands.CreateScreening
{
    public class CreateScreeningCommandValidator : AbstractValidator<CreateScreeningCommand>
    {
        public CreateScreeningCommandValidator(IScreeningRepository screeningRepository, IMovieRepository movieRepository)
        {
            RuleFor(s => s.MovieId)
                .NotEmpty().WithMessage("Please choose movie");

            RuleFor(m => m.CinemaHallId)
                .NotEmpty().WithMessage("Please choose cinema hall");

            RuleFor(m => m.DateTime)
                .NotEmpty().WithMessage("Please enter date and time")
                .Custom((value, context) =>
                {
                    var movie = movieRepository.GetByIdAsync(context.InstanceToValidate.MovieId).Result;

                    var endDateTime = value.AddMinutes(movie.Duration + 10);

                    var existingScreening = screeningRepository.GetByDateTimeAndCinemaHallId(value, endDateTime, context.InstanceToValidate.CinemaHallId).Result;

                    if (existingScreening != null)
                    {
                        context.AddFailure("A screening already exists for the chosen date and time in this cinema hall.");
                    }
                });
        }
    }
}
