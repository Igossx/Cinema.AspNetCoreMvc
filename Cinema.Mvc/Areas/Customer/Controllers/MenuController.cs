using Cinema.Application.Movie.Queries.GetThreeRandomMovies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MenuController : Controller
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Home()
        {
            var randomMovies = await _mediator.Send(new GetThreeRandomMoviesQuery());

            return View(randomMovies);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }


    }
}
