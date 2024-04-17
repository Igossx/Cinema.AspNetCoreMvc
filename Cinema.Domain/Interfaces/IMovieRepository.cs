using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task Create(Movie movie);
        Task Update(Movie movie);
        Task Delete(Movie movie);
        Task<Movie> GetByEncodedNameAsync(string encodedName);
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByTitleAsync(string title);
        Task<IEnumerable<Movie>> GetThreeRandomMoviesAsync();
        Task<IEnumerable<Movie>> GetFourRandomMoviesAsync();
        Movie GetById(int id);
    }
}
