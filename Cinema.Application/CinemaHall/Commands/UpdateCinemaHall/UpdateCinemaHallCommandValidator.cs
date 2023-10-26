using Cinema.Domain.Interfaces;
using FluentValidation;

namespace Cinema.Application.CinemaHall.Commands.DeleteCinemaHall
{
    public class UpdateCinemaHallCommandValidator : AbstractValidator<UpdateCinemaHallCommand>
    {
        public UpdateCinemaHallCommandValidator(ICinemaHallRepository cinemaHallRepository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .Length(7).WithMessage("Name should have 7 characters")
                .Custom((value, context) =>
                {
                    var existingCinemaHall = cinemaHallRepository.GetByNameAsync(value).Result;
                    if (existingCinemaHall != null)
                    {
                        context.AddFailure($"{value} is not unique name for cinema hall");
                    }
                });
        }
    }
}
