using Cinema.Application.Reservation.Commands.DeleteReservation;
using Cinema.Application.Reservation.Queries.GetAllReservationsUser;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(string? sortOrder)
        {
            ViewBag.SortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;

            var reservations = await _mediator.Send(new GetAllReservationsUserQuery());

            switch (sortOrder)
            {
                case "desc":
                    reservations = reservations.OrderByDescending(r => r.TotalCost);
                    break;
                default:
                    reservations = reservations.OrderBy(r => r.TotalCost);
                    break;
            }

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
