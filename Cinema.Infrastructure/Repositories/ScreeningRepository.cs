using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public ScreeningRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(Screening screening)
        {
            _cinemaDbContext.Screenings.Add(screening);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var screening = await _cinemaDbContext.Screenings.FindAsync(id) ??
                throw new NotFoundException("Screening not found.");

            _cinemaDbContext.Screenings.Remove(screening);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(Screening screening)
        {
            _cinemaDbContext.Update(screening);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Screening>> GetAllAsync()
        {
            return await _cinemaDbContext.Screenings.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Screening>> GetScreeningsByMovieAsync(int movieId)
        {
            return await _cinemaDbContext.Screenings
            .Where(s => s.MovieId == movieId)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Screening> GetByIdAsync(int id)
        {
            return await _cinemaDbContext.Screenings.FindAsync(id) ??
                throw new NotFoundException("Screening not found.");
        }
    }
}
