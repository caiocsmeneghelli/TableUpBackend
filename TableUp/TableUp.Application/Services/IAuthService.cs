namespace TableUp.Application.Services
{
    public interface IAuthService
    {
        public string HashPassword(string password);
        public string GenerateJwtToken(Guid userGuid, string userEmail);
    }
}
