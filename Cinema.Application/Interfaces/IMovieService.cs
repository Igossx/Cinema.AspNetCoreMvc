using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Interfaces
{
    public interface IMovieService
    {
        Task<SelectList> GetMoviesSelectListAsync();
    }
}
