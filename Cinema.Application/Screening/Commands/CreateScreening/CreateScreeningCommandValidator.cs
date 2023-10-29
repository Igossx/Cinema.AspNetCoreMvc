using FluentValidation;

namespace Cinema.Application.Screening.Commands.CreateScreening
{
    public class CreateScreeningCommandValidator : AbstractValidator<CreateScreeningCommand>
    {
        public CreateScreeningCommandValidator()
        {
            RuleFor(s => s.MovieId)
                .NotEmpty().WithMessage("Please choose movie");

            RuleFor(m => m.CinemaHallId)
                .NotEmpty().WithMessage("Please choose cinema hall");

            RuleFor(m => m.DateTime)
                .NotEmpty().WithMessage("Please enter date and time");
        }
    }
}
