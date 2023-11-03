using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema.Application.User.Queries
{
    public class ApplicationUserDetailsDto
    {
        public string Id { get; set; } = default!;

        [Display(Name = "Imię")]
        public string FirstName { get; set; } = default!;

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        [Display(Name = "Rola")]
        public string UserRole { get; set; } = default!;

        [Display(Name = "Numer telefonu")]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
