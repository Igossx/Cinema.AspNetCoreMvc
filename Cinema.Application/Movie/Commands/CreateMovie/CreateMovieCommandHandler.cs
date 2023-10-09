using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Cinema.Application.Movie.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Domain.Entities.Movie()
            {
                Title = request.Title,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate,
                Duration = request.Duration,
                Category = request.Category,
                PosterImage = request.PosterImage
            };

            if (movie.PosterImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "movies", "image");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.PosterImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await movie.PosterImage.CopyToAsync(stream, cancellationToken);
                }

                movie.ImagePath = "/movies/image/" + uniqueFileName;
            }

            movie.EncodeTitle();
            await _movieRepository.Create(movie);

            return Unit.Value;
        }
    }
}
