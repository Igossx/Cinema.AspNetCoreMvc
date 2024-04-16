using Cinema.Application.Interfaces;
using Cinema.Application.User.Commands.DeleteUser;
using Cinema.Application.User.Commands.UpdateUserRole;
using Cinema.Application.User.Queries.GetAllUsers;
using Cinema.Application.User.Queries.GetUser;
using Cinema.Mvc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ApplicationUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRoleService _roleService;

        public ApplicationUserController(IMediator mediator, IRoleService roleService)
        {
            _mediator = mediator;
            _roleService = roleService;
        }

        // GET: ApplicationUser
        public async Task<ActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return View(users);
        }

        // GET: ApplicationUser/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var cinemaHall = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            return View(cinemaHall);
        }

        // GET: ApplicationUser/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            var updateApplicationUserCommand = new UpdateUserRoleCommand()
            {
                Id = user.Id,
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Roles = await _roleService.GetRolesSelectListAsync()
            };

            return View(updateApplicationUserCommand);
        }

        // POST: ApplicationUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateUserRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotificaton("success", "User edited.");

            return RedirectToAction(nameof(Index));
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
