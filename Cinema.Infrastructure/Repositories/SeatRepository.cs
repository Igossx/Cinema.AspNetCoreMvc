using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Cinema.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public SeatRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(Seat seat)
        {
            _cinemaDbContext.Seats.Add(seat);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(Seat seat)
        {
            _cinemaDbContext.Seats.Remove(seat);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(Seat seat)
        {
            _cinemaDbContext.Update(seat);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _cinemaDbContext.Seats.AsNoTracking().ToListAsync();
        }

        public async Task<Seat> GetByIdAsync(int id)
        {
            return await _cinemaDbContext.Seats.FindAsync(id) ??
                throw new NotFoundException("Seat not found.");
        }

        public async Task<IEnumerable<Seat>> GetSeatsByScreeningAsync(int screeningId)
        {
            return await _cinemaDbContext.Seats
            .Where(s => s.ScreeningId == screeningId)
            .AsNoTracking().ToListAsync();
        }
    }
}
