using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Cinema.Application.Movie.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieRepository.GetByIdAsync(request.Id);

            movieToUpdate.Title = request.Title;
            movieToUpdate.Description = request.Description;
            movieToUpdate.Category = request.Category;
            movieToUpdate.Duration = request.Duration;
            movieToUpdate.ReleaseDate = request.ReleaseDate;
            movieToUpdate.PosterImage = request.UpdatePosterImage;
            movieToUpdate.Director = request.Director;
            movieToUpdate.TrailerLink = request.TrailerLink;

            if (request.UpdatePosterImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "movies", "image");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.UpdatePosterImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdatePosterImage.CopyToAsync(stream, cancellationToken);
                }

                movieToUpdate.ImagePath = "/movies/image/" + uniqueFileName;
            }

            movieToUpdate.EncodeTitle();
            await _movieRepository.Update(movieToUpdate);

            return Unit.Value;
        }
    }
}
