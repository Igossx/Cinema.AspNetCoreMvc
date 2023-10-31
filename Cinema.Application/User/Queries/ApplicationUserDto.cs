namespace Cinema.Application.User.Queries
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = default!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;


    }
}
