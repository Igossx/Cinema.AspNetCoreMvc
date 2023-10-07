using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public CartRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(Cart cart)
        {
            _cinemaDbContext.Carts.Add(cart);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cart = await _cinemaDbContext.Carts.FindAsync(id) ??
               throw new NotFoundException("Cart not found.");

            _cinemaDbContext.Carts.Remove(cart);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(Cart cart)
        {
            _cinemaDbContext.Carts.Update(cart);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _cinemaDbContext.Carts.FindAsync(id) ??
                throw new NotFoundException("Cart not found.");
        }

        public async Task<Cart> GetByUserAsync(string userId)
        {
            return await _cinemaDbContext.Carts.FirstOrDefaultAsync(s => s.UserId == userId) ??
                throw new NotFoundException("User not found.");
        }
    }
}
