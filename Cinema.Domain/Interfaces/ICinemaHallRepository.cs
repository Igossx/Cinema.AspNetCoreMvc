using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface ICinemaHallRepository
    {
        Task Create(CinemaHall cinemaHall);
        Task Update(CinemaHall cinemaHall);
        Task Delete(int id);
        Task<CinemaHall> GetByIdAsync(int id);
        Task<IEnumerable<CinemaHall>> GetAllAsync();
    }
}
