﻿using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Persistence
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Ignore(m => m.PosterImage);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.TotalCost)
                .HasPrecision(10, 2);
        }
    }
}
