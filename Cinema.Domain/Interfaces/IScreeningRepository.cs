using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IScreeningRepository
    {
        Task Create(Screening screening);
        Task Update(Screening screening);
        Task Delete(Screening screening);
        Task<Screening> GetByIdAsync(int id);
        Task<IEnumerable<Screening>> GetAllAsync();
        Task<IEnumerable<Screening>> GetScreeningsByMovieAsync(int movieId);
    }
}
