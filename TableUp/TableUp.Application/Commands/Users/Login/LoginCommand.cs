using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Users.Login
{
    public class LoginCommand : IRequest<Result>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public void Tratar()
        {
            Username = Username.Contains('@') ? Username.Split('@')[0] : Username;
        }
    }
}
