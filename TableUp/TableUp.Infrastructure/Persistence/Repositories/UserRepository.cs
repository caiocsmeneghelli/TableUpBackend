namespace TableUp.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TableUp.Domain.Entities;
    using TableUp.Domain.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly TableUpDbContext _dbContext;

        public UserRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(User entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Guid == id);
        }

        public async Task<List<User>> ListAllAsync(bool active)
        {
            if (active)
            {
                return await _dbContext.Users.Where(c => c.Status == Domain.Enums.EStatus.Active)
                .AsNoTracking()
                .ToListAsync();
            }

            return await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}