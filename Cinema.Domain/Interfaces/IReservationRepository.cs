﻿using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task Create(Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(Reservation reservation);
        Task<Reservation> GetByIdAsync(Guid id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Seat>> GetSelectedSeatsAsync(IEnumerable<int> seatIds);
        Task<IEnumerable<Reservation>> GetAllReservationsForUser(string UserId);
    }
}
