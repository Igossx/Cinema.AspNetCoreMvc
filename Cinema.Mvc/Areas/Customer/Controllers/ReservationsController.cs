using Cinema.Application.Reservation.Queries.GetAllReservationsUser;
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

        public async Task<IActionResult> Index()
        {
            var reservations = await _mediator.Send(new GetAllReservationsUserQuery());

            return View(reservations);
        }
    }
}
