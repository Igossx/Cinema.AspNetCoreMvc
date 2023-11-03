using MediatR;

namespace Cinema.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {

    }
}
