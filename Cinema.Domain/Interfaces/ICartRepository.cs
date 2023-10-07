using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(int id);
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetByUserAsync(string userId);
    }
}
