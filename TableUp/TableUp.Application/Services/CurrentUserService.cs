using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TableUp.Application.Services
{

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public Guid UserId =>
            Guid.Parse(
                _httpContextAccessor.HttpContext?.User?
                    .FindFirst(ClaimTypes.NameIdentifier).Value ?? Guid.Empty.ToString()
            );

        public string Email =>
            _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Email).Value ?? Guid.Empty.ToString();

        public string[] Roles =>
            _httpContextAccessor.HttpContext?.User?
                .FindAll(ClaimTypes.Role)
                .Select(r => r.Value)
                .ToArray() ?? [];
    }

}
