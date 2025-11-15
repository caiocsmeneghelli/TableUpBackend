using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;
using TableUp.Domain.Services;

namespace TableUp.Application.Commands.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly CreateUserCommandValidator _validator;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository,
            IAuthService authService, CreateUserCommandValidator validator)
        {
            _userRepository = userRepository;
            _authService = authService;
            _validator = validator;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join("; ", errors);
                return Result.Failure(errorMessage);
            }

            string hashPassword = _authService.HashPassword(request.Password);
            User user = request.ToDomain(hashPassword);
            User createdUser =  await _userRepository.AddAsync(user);   
            return Result.Success(createdUser.Guid);
        }
    }
}