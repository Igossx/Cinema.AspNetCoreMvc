using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task Create(Movie movie);
        Task Update(Movie movie);
        Task Delete(int id);
        Task<Movie> GetByEncodedNameAsync(string encodedName);
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
