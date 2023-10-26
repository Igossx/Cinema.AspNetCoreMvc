using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface ICinemaHallRepository
    {
        Task Create(CinemaHall cinemaHall);
        Task Update(CinemaHall cinemaHall);
        Task Delete(CinemaHall cinemaHall);
        Task<CinemaHall> GetByIdAsync(int id);
        Task<IEnumerable<CinemaHall>> GetAllAsync();
        Task<CinemaHall?> GetByNameAsync(string name);
    }
}
