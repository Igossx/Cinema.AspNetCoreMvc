using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public GetAllUsersQueryHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationUserRepository.GetAllAsync();

            var usersDtos = users.Select(u => new ApplicationUserDto()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            });

            return usersDtos;
        }
    }
}
