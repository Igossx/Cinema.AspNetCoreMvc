using Cinema.Application.Interfaces;
using Cinema.Application.Screening.Commands.CreateScreening;
using Cinema.Application.Screening.Commands.DeleteScreening;
using Cinema.Application.Screening.Queries.GetAllScreenings;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ScreeningController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMovieService _movieService;
        private readonly ICinemaHallService _cinemaHallService;

        public ScreeningController(IMediator mediator, IMovieService movieService, ICinemaHallService cinemaHallService)
        {
            _mediator = mediator;
            _movieService = movieService;
            _cinemaHallService = cinemaHallService;
        }

        // GET: Screening
        public async Task<IActionResult> Index()
        {
            var screenings = await _mediator.Send(new GetAllScreeningQuery());

            return View(screenings);
        }

        // GET: Screening/Create
        public async Task<ActionResult> Create()
        {
            var command = new CreateScreeningCommand()
            {
                Movies = await _movieService.GetMoviesSelectListAsync(),
                CinemaHalls = await _cinemaHallService.GetCinemaHallsSelectListAsync(),
            };

            command.DateTime = DateTime.Now.Date;

            return View(command);
        }

        // POST: Screening/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateScreeningCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "Screening created.");

            return RedirectToAction(nameof(Index));
        }

        // POST: CinemaHall/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteScreeningCommand() { Id = id });

            this.SetNotificaton("success", "Screening deleted.");

            return RedirectToAction(nameof(Index));
        }
    }
}
