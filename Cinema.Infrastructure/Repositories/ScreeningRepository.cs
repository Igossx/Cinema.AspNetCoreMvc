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

        public async Task Delete(Screening screening)
        {
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

        public async Task<Screening?> GetByDateTimeAndCinemaHallId(DateTime startDateTime, DateTime endDateTime, int cinemaHallId)
        {
            return await _cinemaDbContext.Screenings.FirstOrDefaultAsync(s =>
                s.CinemaHallId == cinemaHallId &&
                (DateTime.Compare(startDateTime, s.DateTime) >= 0 && DateTime.Compare(startDateTime, s.EndDateTime) < 0) ||
                (DateTime.Compare(endDateTime, s.DateTime) > 0 && DateTime.Compare(endDateTime, s.EndDateTime) <= 0) ||
                (DateTime.Compare(startDateTime, s.DateTime) <= 0 && DateTime.Compare(endDateTime, s.EndDateTime) >= 0));
        }
    }
}
