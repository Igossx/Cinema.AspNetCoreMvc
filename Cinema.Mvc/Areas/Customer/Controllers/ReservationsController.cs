using Cinema.Application.Reservation.Commands.DeleteReservation;
using Cinema.Application.Reservation.Commands.UpdateIsConfirmed;
using Cinema.Application.Reservation.Queries.GetAllReservationsUser;
using Cinema.Application.Reservation.Queries.GetPaymentForm;
using Cinema.Application.Reservation.Queries.GetReservationUser;
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

        // GET: Reservation/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var reservation = await _mediator.Send(new GetReservationByIdUserQuery() { Id = id });

            return View(reservation);
        }

        // POST Reservation/Details/5/ConfirmReservation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmReservation(Guid id)
        {
            await _mediator.Send(new UpdateIsConfirmedReservationCommand() { Id = id });

            this.SetNotificaton("success", "Reservation confirmed.");

            return RedirectToAction(nameof(Index));
        }

        // GET: Screenings/Details/5/PayForReservation
        public async Task<IActionResult> PayForReservation(Guid id)
        {
            var paymentForm = await _mediator.Send(new GetPaymentFormQuery() { Id = id });

            return View(paymentForm);
        }
    }
}
