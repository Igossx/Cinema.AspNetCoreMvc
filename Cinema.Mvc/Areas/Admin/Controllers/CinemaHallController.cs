using Cinema.Application.CinemaHall.Commands.CreateCinemaHall;
using Cinema.Application.CinemaHall.Commands.DeleteCinemaHall;
using Cinema.Application.CinemaHall.Queries.GetAllCinemaHalls;
using Cinema.Application.CinemaHall.Queries.GetCinemaHall;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaHallController : Controller
    {
        private readonly IMediator _mediator;

        public CinemaHallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: CinemaHall
        public async Task<ActionResult> Index()
        {
            var cinemaHalls = await _mediator.Send(new GetAllCinemaHallsQuery());

            return View(cinemaHalls);
        }

        // GET: CinemaHall/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cinemaHall = await _mediator.Send(new GetCinemaHallByIdQuery() { Id = id });

            return View(cinemaHall);
        }

        // GET: CinemaHall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaHall/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCinemaHallCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "Cinema Hall created.");

            return RedirectToAction(nameof(Index));
        }

        // GET: CinemaHall/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cinemaHall = await _mediator.Send(new GetCinemaHallByIdQuery() { Id = id });

            var updateCinemaHallCommand = new UpdateCinemaHallCommand()
            {
                Id = cinemaHall.Id,
                Name = cinemaHall.Name
            };

            return View(updateCinemaHallCommand);
        }

        // POST: CinemaHall/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateCinemaHallCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "Cinama Hall edited.");

            return RedirectToAction(nameof(Index));
        }

        // POST: CinemaHall/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCinemaHallCommand() { Id = id });

            this.SetNotificaton("success", "Cinema Hall deleted.");

            return RedirectToAction(nameof(Index));
        }
    }
}
