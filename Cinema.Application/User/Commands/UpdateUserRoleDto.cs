namespace Cinema.Application.User.Commands
{
    public class UpdateUserRoleDto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string NewRoleName { get; set; } = default!;
    }
}
