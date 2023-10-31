using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public DeleteUserCommandHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _applicationUserRepository.GetByIdAsync(request.Id);

            await _applicationUserRepository.Delete(userToDelete);

            return Unit.Value;
        }
    }
}
