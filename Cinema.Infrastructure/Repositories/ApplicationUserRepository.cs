using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public ApplicationUserRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Delete(ApplicationUser applicationUser)
        {
            _cinemaDbContext.Users.Remove(applicationUser);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _cinemaDbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _cinemaDbContext.Users.FindAsync(id) ??
                throw new NotFoundException("Movie not found.");
        }

        public async Task Update(ApplicationUser applicationUser)
        {
            _cinemaDbContext.Users.Update(applicationUser);
            await _cinemaDbContext.SaveChangesAsync();
        }
    }
}
