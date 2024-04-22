using FluentValidation;

namespace Cinema.Application.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(command => command.ScreeningId)
            .NotEmpty().WithMessage("ScreeningId is required.");

            RuleFor(command => command.SelectedSeats)
                .Must(seats => seats != null && seats.Any())
                .WithMessage("At least one seat must be selected.");

            RuleFor(command => command.TicketType)
                .IsInEnum().WithMessage("Invalid ticket type.");
        }
    }
}
