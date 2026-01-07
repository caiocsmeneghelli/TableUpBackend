using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly TableUpDbContext _dbContext;

        public MenuItemRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuItem> AddAsync(MenuItem entity)
        {
            await _dbContext.MenuItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(MenuItem entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(Guid id)
        {
            return await _dbContext.MenuItems.SingleOrDefaultAsync(reg => reg.Guid == id);
        }

        public async Task<List<MenuItem>> ListAllAsync(bool active)
        {
            if (active)
            {
                return await _dbContext.MenuItems.Where(c => c.Status == Domain.Enums.EStatus.Active)
                .Where(c => c.Category.Status == Domain.Enums.EStatus.Active)
                .Include(reg => reg.Category)
                .AsNoTracking()
                .ToListAsync();
            }

            return await _dbContext.MenuItems
                .AsNoTracking()
                .Include(reg =>  reg.Category)
                .ToListAsync();
        }

        public async Task UpdateAsync(MenuItem entity)
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
