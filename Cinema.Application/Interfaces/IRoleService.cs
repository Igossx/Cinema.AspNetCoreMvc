using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Interfaces
{
    public interface IRoleService
    {
        Task<SelectList> GetRolesSelectListAsync();
    }
}
