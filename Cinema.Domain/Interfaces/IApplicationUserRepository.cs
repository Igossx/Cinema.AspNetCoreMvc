using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task Update(ApplicationUser applicationUser);
        Task Delete(ApplicationUser applicationUser);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
