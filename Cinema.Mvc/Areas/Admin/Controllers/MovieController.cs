using Cinema.Application.Movie.Commands.CreateMovie;
using Cinema.Application.Movie.Commands.DeleteMovie;
using Cinema.Application.Movie.Commands.UpdateMovie;
using Cinema.Application.Movie.Queries.GetAllMovies;
using Cinema.Application.Movie.Queries.GetMovie; 
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Movie
        public async Task<ActionResult> Index()
        {
            var movies = await _mediator.Send(new GetAllMoviesQuery());

            return View(movies);
        }

        // GET: Movie/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery() { Id = id });

            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMovieCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "Movie created.");

            return RedirectToAction(nameof(Index));
        }

        // GET: Movie/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery() { Id = id });

            var updateMovieCommand = new UpdateMovieCommand()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Category = movie.Category,
                UpdatePosterImage = null,
                ImagePath = movie.ImagePath,
                Director = movie.Director,
                TrailerLink = movie.TrailerLink
            };

            return View(updateMovieCommand);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateMovieCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "Movie edited.");

            return RedirectToAction(nameof(Index));
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMovieCommand() { Id = id });

            this.SetNotificaton("success", "Movie deleted.");

            return RedirectToAction(nameof(Index));
        }
    }
}
