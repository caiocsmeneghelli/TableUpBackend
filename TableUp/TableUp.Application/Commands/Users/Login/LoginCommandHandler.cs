using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Users.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // validar usuário

            string passwordHash = _authService.HashPassword(request.Password);
            request.Tratar();
            var user = await _userRepository.GetByUsernameAndPasswordHash(request.Username, passwordHash);

            if(user == null)
            {
                return Result.Failure("Usuário ou senha incorreta.");
            }

            // gerar token
            var token = _authService.GenerateJwtToken(user.Guid, user.Email);
            return Result.Success(token);
        }
    }
}
