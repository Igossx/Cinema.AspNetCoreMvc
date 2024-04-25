using Microsoft.AspNetCore.Identity;

namespace Cinema.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
