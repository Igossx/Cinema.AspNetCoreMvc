using Cinema.Application.User.Commands.DeleteUser;
using Cinema.Application.User.Queries.GetAllUsers;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApplicationUserController : Controller
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ApplicationUser
        public async Task<ActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return View(users);
        }



        // POST: ApplicationUser/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = id });

            this.SetNotificaton("success", "User deleted.");

            return RedirectToAction(nameof(Index));
        }
    }
}
