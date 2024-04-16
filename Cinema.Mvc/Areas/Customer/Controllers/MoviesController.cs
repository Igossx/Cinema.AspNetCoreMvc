using Cinema.Application.CinemaHall.Queries.GetCinemaHall;
using Cinema.Application.Movie.Queries;
using Cinema.Application.Movie.Queries.GetAllMovies;
using Cinema.Application.Movie.Queries.GetMovie;
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
        public async Task<IActionResult> Index(int? page)
        {
            const int pageSize = 2;

            var allMovies = await _mediator.Send(new GetAllMoviesQuery());

            var pageNumber = page ?? 1;
            var paginatedMovies = allMovies.ToPagedList(pageNumber, pageSize);

            return View(paginatedMovies);
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery() { Id = id });

            return View(movie);
        }
    }
}
