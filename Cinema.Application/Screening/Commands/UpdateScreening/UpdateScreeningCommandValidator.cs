using FluentValidation;

namespace Cinema.Application.Screening.Commands.UpdateScreening
{
    public class UpdateScreeningCommandValidator : AbstractValidator<UpdateScreeningCommand>
    {
        public UpdateScreeningCommandValidator()
        {
            RuleFor(s => s.MovieId)
                 .NotEmpty().WithMessage("Please choose movie");

            RuleFor(m => m.DateTime)
                .NotEmpty().WithMessage("Please enter date and time");
        }
    }
}
