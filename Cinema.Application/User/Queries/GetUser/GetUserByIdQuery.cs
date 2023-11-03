using MediatR;

namespace Cinema.Application.User.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<ApplicationUserDetailsDto>
    {
        public string Id { get; set; } = default!;
    }
}
