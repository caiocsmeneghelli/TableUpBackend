using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Domain.Repositories;
using TableUp.Domain.Services;

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
