using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task Create(Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(int id);
        Task<Reservation> GetByIdAsync(Guid id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Seat>> GetSelectedSeatsAsync(IEnumerable<int> seatIds);
    }
}
