using Cinema.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<SelectList> GetRolesSelectListAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return new SelectList(roles, "Name", "Name");
        }
    }
}
