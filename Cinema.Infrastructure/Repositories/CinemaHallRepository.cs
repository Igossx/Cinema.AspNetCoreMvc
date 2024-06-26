﻿using Cinema.Domain.Entities;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Repositories
{
    public class CinemaHallRepository : ICinemaHallRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public CinemaHallRepository(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task Create(CinemaHall cinemaHall)
        {
            _cinemaDbContext.CinemaHalls.Add(cinemaHall);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Delete(CinemaHall cinemaHall)
        {
            _cinemaDbContext.CinemaHalls.Remove(cinemaHall);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task Update(CinemaHall cinemaHall)
        {
            _cinemaDbContext.CinemaHalls.Update(cinemaHall);
            await _cinemaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CinemaHall>> GetAllAsync()
        {
            return await _cinemaDbContext.CinemaHalls.AsNoTracking().ToListAsync();
        }

        public async Task<CinemaHall> GetByIdAsync(int id)
        {
            return await _cinemaDbContext.CinemaHalls.FindAsync(id) ??
                throw new NotFoundException("CinemaHall not found.");
        }

        public async Task<CinemaHall?> GetByNameAsync(string name)
        {
            return await _cinemaDbContext.CinemaHalls.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
