using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Interfaces
{
    public interface ICinemaHallService
    {
        Task<SelectList> GetCinemaHallsSelectListAsync();
    }
}
