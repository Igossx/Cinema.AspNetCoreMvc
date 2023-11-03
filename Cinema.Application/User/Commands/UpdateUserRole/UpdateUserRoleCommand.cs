using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommand : UpdateUserRoleDto, IRequest
    {
        public string Id { get; set; } = default!;
        public SelectList? Roles { get; set; }
    }
}
