using Cinema.Application.Interfaces;
using Cinema.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Application.Services
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public CinemaHallService(ICinemaHallRepository cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public async Task<SelectList> GetCinemaHallsSelectListAsync()
        {
            var cinemaHalls = await _cinemaHallRepository.GetAllAsync();
            return new SelectList(cinemaHalls,
                nameof(Domain.Entities.CinemaHall.Id), nameof(Domain.Entities.CinemaHall.Name));
        }
    }
}
