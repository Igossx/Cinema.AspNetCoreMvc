using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public MovieRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(Movie movie)
        {
            _cinemaDbContext.Movies.Add(movie);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(Movie movie)
        {
            _cinemaDbContext.Movies.Remove(movie);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(Movie movie)
        {
            _cinemaDbContext.Movies.Update(movie);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _cinemaDbContext.Movies.AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetByEncodedNameAsync(string encodedTitle)
        {
            return await _cinemaDbContext.Movies.FirstOrDefaultAsync(m => m.EncodedTitle == encodedTitle) ??
                throw new NotFoundException("Movie not found.");
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _cinemaDbContext.Movies.FindAsync(id) ??
                throw new NotFoundException("Movie not found.");
        }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            return await _cinemaDbContext.Movies.FirstOrDefaultAsync(m => m.Title.ToLower() == title.ToLower());
        }

        public async Task<IEnumerable<Movie>> GetThreeRandomMoviesAsync()
        {
            return await _cinemaDbContext.Movies.OrderBy(x => Guid.NewGuid()).Take(3).ToListAsync();
        }

        public Movie GetById(int id)
        {
            return _cinemaDbContext.Movies.Find(id) ??
                throw new NotFoundException("Movie not found.");
        }
    }
}
