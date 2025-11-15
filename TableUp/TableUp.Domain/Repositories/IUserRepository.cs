using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetByUsernameAndPasswordHash(string username, string passwordHash);
    }
}