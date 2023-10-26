using Cinema.Domain.Interfaces;
using FluentValidation;

namespace Cinema.Application.CinemaHall.Commands.CreateCinemaHall
{
    public class CreateCinemaHallCommandValidator : AbstractValidator<CreateCinemaHallCommand>
    {
        public CreateCinemaHallCommandValidator(ICinemaHallRepository cinemaHallRepository)
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

            RuleFor(c => c.TotalSeats)
                .NotEmpty().WithMessage("Please enter total seats")
                .Must(seats => seats == 132 || seats == 72).WithMessage("The number of seats must be 132 or 72");
        }
    }
}
