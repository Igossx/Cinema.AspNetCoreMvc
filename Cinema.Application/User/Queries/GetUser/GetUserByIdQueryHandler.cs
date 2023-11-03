using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.User.Queries.GetUser
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserDetailsDto>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdQueryHandler(IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        public async Task<ApplicationUserDetailsDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserRepository.GetByIdAsync(request.Id);

            var userRoles = await _userManager.GetRolesAsync(user);

            var userDto = new ApplicationUserDetailsDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                UserRole = string.Join(", ", userRoles),
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }
    }
}
