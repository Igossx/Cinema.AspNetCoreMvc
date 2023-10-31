using MediatR;

namespace Cinema.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; } = default!;
    }
}
