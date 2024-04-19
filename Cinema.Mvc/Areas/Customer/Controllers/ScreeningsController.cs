using Cinema.Application.Screening.Queries.GetAllScreenings;
using Cinema.Application.Screening.Queries.GetAllScreeningsByMovie;
using Cinema.Application.Screening.Queries.GetScreening;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Cinema.Mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ScreeningsController : Controller
    {
        private readonly IMediator _mediator;

        public ScreeningsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Screenings/ByMovie
        public async Task<IActionResult> ByMovie(int? page, int id, DateTime? searchDate)
        {
            const int pageSize = 2;

            var allScreenings = await _mediator.Send(new GetAllScreeningsByMovieQuery() { MovieId = id });

            if (searchDate.HasValue)
            {
                allScreenings = allScreenings.Where(s => s.ScreeningDate.Date == searchDate.Value.Date);
            }

            var pageNumber = page ?? 1;
            var paginatedScreenings = allScreenings.ToPagedList(pageNumber, pageSize);

            ViewBag.MovieId = id;
            ViewBag.SearchDate = searchDate;

            return View(paginatedScreenings);
        }

        // GET: Screenings
        public async Task<IActionResult> Index(int? page, DateTime? searchDate, string? searchString)
        {
            const int pageSize = 2;

            var allScreenings = await _mediator.Send(new GetAllScreeningsQuery());

            if (searchDate.HasValue)
            {
                allScreenings = allScreenings.Where(s => s.ScreeningDate.Date == searchDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                allScreenings = allScreenings.Where(s => s.MovieTitle.ToLower().Contains(searchString.ToLower()));
            }

            var pageNumber = page ?? 1;
            var paginatedScreenings = allScreenings.ToPagedList(pageNumber, pageSize);

            ViewBag.SearchDate = searchDate;
            ViewBag.SearchString = searchString;

            return View(paginatedScreenings);
        }

        // GET: Screenings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var screening = await _mediator.Send(new GetScreeningByIdQuery() { Id = id });

            return View(screening);
        }
    }
}
