using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Services
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string Email { get; }
        string[] Roles { get; }
        bool IsAuthenticated { get; }
    }
}
