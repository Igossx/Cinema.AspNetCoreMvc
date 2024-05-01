using Cinema.Domain.Interfaces;
using FluentValidation;

namespace Cinema.Application.Movie.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator(IMovieRepository movieRepository)
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Title should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Title should have maxium of 20 characters")
                .Custom((value, context) =>
                {
                    var existingMovie = movieRepository.GetByTitleAsync(value).Result;
                    if (existingMovie != null)
                    {
                        context.AddFailure($"{value} is not unique title for movie");
                    }
                });

            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(m => m.ReleaseDate)
                .NotEmpty().WithMessage("Please enter release date");

            RuleFor(m => m.Category)
                .NotEmpty().WithMessage("Please enter category");

            RuleFor(m => m.Duration)
                .NotEmpty().WithMessage("Please enter film duration")
                .InclusiveBetween(1, 200).WithMessage("Duration must be between 1 and 200 minutes.");

            RuleFor(m => m.Director)
                .NotEmpty().WithMessage("Please enter director");

            RuleFor(m => m.TrailerLink)
                .NotEmpty().WithMessage("Please enter movie trailer");
        }
    }
}
