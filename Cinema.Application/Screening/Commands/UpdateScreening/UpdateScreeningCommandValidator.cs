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

            RuleFor(m => m.RegularTicketPrice)
                .NotEmpty().WithMessage("Please enter regular ticket price")
                .GreaterThan(0).WithMessage("Please enter an amount greater than zero");

            RuleFor(m => m.ReducedTicketPrice)
                .NotEmpty().WithMessage("Please enter reduced ticket price")
                .GreaterThan(0).WithMessage("Please enter an amount greater than zero");
        }
    }
}
