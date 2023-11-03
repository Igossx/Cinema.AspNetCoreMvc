using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllUsersQueryHandler(IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationUserRepository.GetAllAsync();

            var usersDtos = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                var userDto = new ApplicationUserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!
                };

                var userRoles = await _userManager.GetRolesAsync(user);

                userDto.UserRole = string.Join(", ", userRoles);

                usersDtos.Add(userDto);
            }

            return usersDtos;
        }
    }
}
