using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.User.Queries
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = default!;

        [Display(Name = "Imię")]
        public string FirstName { get; set; } = default!;

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}
