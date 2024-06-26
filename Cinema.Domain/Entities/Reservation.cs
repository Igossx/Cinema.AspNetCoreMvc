﻿using Cinema.Domain.Enums;

namespace Cinema.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = default!;

        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

        public DateTime ReservationTime { get; set; } = DateTime.UtcNow;

        public decimal TotalCost { get; set; } = 0;
        public int TotalSeats { get; set; } = 0;
        public bool IsConfirmed { get; set; } = false;

        public TicketType TicketType { get; set; }

        public bool IsPaidFor { get; set; } = false;

        public string? Seats { get; set; }
    }
}