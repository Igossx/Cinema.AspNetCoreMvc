using Cinema.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public UpdateUserRoleCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            var existingRoles = await _userManager.GetRolesAsync(user!);

            var userRolesToRemove = existingRoles.Except(new[] { request.NewRoleName }).ToList();

            var userRolesToAdd = new List<string> { request.NewRoleName };

            await _userManager.RemoveFromRolesAsync(user!, userRolesToRemove);
            await _userManager.AddToRolesAsync(user!, userRolesToAdd);

            return Unit.Value;
        }
    }
}
