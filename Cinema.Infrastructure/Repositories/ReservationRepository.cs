using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public ReservationRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(Reservation reservation)
        {
            _cinemaDbContext.Reservations.Add(reservation);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(Reservation reservation)
        {
            _cinemaDbContext.Reservations.Remove(reservation);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(Reservation reservation)
        {
            _cinemaDbContext.Reservations.Update(reservation);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _cinemaDbContext.Reservations.AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(Guid id)
        {
            return await _cinemaDbContext.Reservations.FindAsync(id) ??
                throw new NotFoundException("Reservation not found.");
        }

        public async Task<IEnumerable<Seat>> GetSelectedSeatsAsync(IEnumerable<int> seatIds)
        {
            return await _cinemaDbContext.Seats
                .Where(s => seatIds.Contains(s.Id))
                .AsNoTracking().ToListAsync();
        }
    }
}
