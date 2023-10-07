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

        public async Task Delete(int id)
        {
            var movie = await _cinemaDbContext.Movies.FindAsync(id) ??
                throw new NotFoundException("Movie not found");

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
    }
}
