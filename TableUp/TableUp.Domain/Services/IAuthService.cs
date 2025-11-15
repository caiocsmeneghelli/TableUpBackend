using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Domain.Services
{
    public interface IAuthService
    {
        public string HashPassword(string password);
        public string GenerateJwtToken(Guid userGuid, string userEmail);
    }
}
