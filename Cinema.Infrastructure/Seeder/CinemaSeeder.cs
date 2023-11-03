using Cinema.Domain.Entities;
using Cinema.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Seeder
{
    public class CinemaSeeder
    {
        private readonly CinemaDbContext _cinemaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CinemaSeeder(CinemaDbContext cinemaDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _cinemaDbContext = cinemaDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            if (await _cinemaDbContext.Database.CanConnectAsync() && _cinemaDbContext.Database.IsRelational())
            {
                var pendingMigrations = _cinemaDbContext.Database.GetPendingMigrations();

                if (pendingMigrations is not null && pendingMigrations.Any())
                {
                    _cinemaDbContext.Database.Migrate();
                }

                await CreateRoles();

                await CreateUserAdmin();
            }
        }

        private async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }

        private async Task CreateUserAdmin()
        {
            if (_userManager.FindByEmailAsync("admin@gmail.com") is not null)
            {
                var user = new ApplicationUser()
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var password = "$Admin1230$";

                var userAdmin = await _userManager.CreateAsync(user, password);

                if (userAdmin.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
