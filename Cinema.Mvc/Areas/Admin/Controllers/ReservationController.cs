using Cinema.Application.Reservation.Commands.DeleteReservation;
using Cinema.Application.Reservation.Queries.GetAllReservations;
using Cinema.Application.Screening.Commands.DeleteScreening;
using Cinema.Domain.Interfaces;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IMediator mediator, IReservationRepository reservationRepository)
        {
            _mediator = mediator;
            _reservationRepository = reservationRepository;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());

            return View(reservations);
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteReservationCommand() { Id = id });

            this.SetNotificaton("success", "Reservation deleted.");

            return RedirectToAction(nameof(Index));
        }
    }
}
