using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Entities;

namespace TableUp.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public User ToDomain(string passwordHash)
        {
            string userName = Email.Split('@')[0];
            return new User(
                Name,
                userName,
                Email,
                passwordHash
            );
        }
    }
}