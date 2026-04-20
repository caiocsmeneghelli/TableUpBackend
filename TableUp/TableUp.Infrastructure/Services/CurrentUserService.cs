using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        private static Guid? _systemUserId;
        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public Guid UserId
        {
            get
            {
                {
                    var context = _httpContextAccessor.HttpContext;

                    // 1. Tenta pegar via Claims (padrão ASP.NET)
                    var claim = context?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    if (!string.IsNullOrWhiteSpace(claim) &&
                        Guid.TryParse(claim, out var userIdFromClaim))
                    {
                        return userIdFromClaim;
                    }

                    // 2. Tenta pegar do middleware (fallback atual)
                    if (context?.Items["UserId"] is string userIdStr &&
                        Guid.TryParse(userIdStr, out var userIdFromMiddleware))
                    {
                        return userIdFromMiddleware;
                    }

                    // 3. Fallback final → system user
                    return GetSystemUserId();
                }
            }
        }

        public string Email =>
            _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Email).Value ?? Guid.Empty.ToString();

        public string[] Roles =>
            _httpContextAccessor.HttpContext?.User?
                .FindAll(ClaimTypes.Role)
                .Select(r => r.Value)
                .ToArray() ?? [];


        private Guid GetSystemUserId()
        {
            if (_systemUserId.HasValue)
                return _systemUserId.Value;

            var systemUser = _userRepository.GetSystemUser(); // ideal usar IsSystem
            _systemUserId = systemUser.Guid;

            return _systemUserId.Value;
        }
    }
}
