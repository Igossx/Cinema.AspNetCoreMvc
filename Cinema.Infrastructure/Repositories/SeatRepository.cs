using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Cinema.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Text;

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

        public async Task ReserveSeat(IEnumerable<Seat> seatsToReserve)
        {
            foreach (var seat in seatsToReserve)
            {
                seat.IsReserved = true;
                _cinemaDbContext.Update(seat);
            }

            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task AssignToReservation(IEnumerable<Seat> seatsToAssign, Guid reservationId)
        {
            foreach (var seat in seatsToAssign)
            {
                seat.ReservationId = reservationId;
                _cinemaDbContext.Update(seat);
            }

            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task RemoveFromReservation(Guid reservationId)
        {
            var allSeatsForReservation = await GetAllSeatsFromReservation(reservationId);

            foreach (var seat in allSeatsForReservation)
            {
                seat.ReservationId = null;
                seat.IsReserved = false;
                _cinemaDbContext.Update(seat);
            }

            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<string> GetStringFromSeats(IEnumerable<Seat> seats)
        {
            var stringBuilder = new StringBuilder();

            foreach (var seat in seats)
            {
                stringBuilder.Append(seat.RowSign);
                stringBuilder.Append(seat.SeatNumber.ToString());
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public async Task<List<Seat>> GetAllSeatsFromReservation(Guid reservationId)
        {
            return await _cinemaDbContext.Seats
                .Where(s => s.ReservationId == reservationId)
                .ToListAsync();
        }
    }
}
