using Cinema.Application.Movie.Queries.GetAllMovies;
using Cinema.Application.Movie.Queries.GetFourRandomMovies;
using Cinema.Application.Movie.Queries.GetMovie;
using Cinema.Domain.Enums;
using Cinema.Mvc.Areas.Customer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Cinema.Mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MoviesController : Controller
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Movies
        public async Task<IActionResult> Index(int? page, string? searchString, FilmCategory? filmCategory)
        {
            const int pageSize = 2;

            var allMovies = await _mediator.Send(new GetAllMoviesQuery());

            if (!string.IsNullOrEmpty(searchString))
            {
                allMovies = allMovies.Where(m => m.Title.ToLower().Contains(searchString.ToLower()));
            }

            if (filmCategory.HasValue)
            {
                allMovies = allMovies.Where(m => m.Category == filmCategory);
            }

            var pageNumber = page ?? 1;
            var paginatedMovies = allMovies.ToPagedList(pageNumber, pageSize);

            ViewBag.SearchString = searchString;
            ViewBag.FilmCategory = filmCategory;

            return View(paginatedMovies);
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery() { Id = id });

            var randomMovies = await _mediator.Send(new GetFourRandomMoviesQuery());

            var viewModel = new MovieDetailsViewModel
            {
                Movie = movie,
                RandomMovies = randomMovies
            };

            return View(viewModel);
        }
    }
}
