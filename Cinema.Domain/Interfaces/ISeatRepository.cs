using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task Create(Seat seat);
        Task Update(Seat seat);
        Task Delete(Seat seat);
        Task<Seat> GetByIdAsync(int id);
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<IEnumerable<Seat>> GetSeatsByScreeningAsync(int screeningId);
        Task ReserveSeat(IEnumerable<Seat> seatsToReserve);
        Task AssignToReservation(IEnumerable<Seat> seatsToAssign, Guid reservationId);
    }
}
