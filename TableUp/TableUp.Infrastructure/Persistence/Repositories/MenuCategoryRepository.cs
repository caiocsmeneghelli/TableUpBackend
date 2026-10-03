using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly TableUpDbContext _dbContext;

        public MenuCategoryRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuCategory> AddAsync(MenuCategory entity)
        {
            await _dbContext.MenuCategories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(MenuCategory entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MenuCategory?> GetByIdAsync(Guid id)
        {
            var category = await _dbContext.MenuCategories
                .Include(c => c.Restaurant)
                .Include(c => c.CreatedBy)
                .FirstOrDefaultAsync(c => c.Guid == id);
            return category;
        }


        public async Task<List<MenuCategory>> ListAllAsync(bool active)
        {
            if (active)
            {
                return await _dbContext.MenuCategories
                    .Where(c => c.Status == Domain.Enums.EStatus.Active)
                    .Include(c => c.Restaurant)
                    .Include(c => c.CreatedBy)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await _dbContext.MenuCategories
                .Include(c => c.Restaurant)
                .Include(c => c.CreatedBy)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(MenuCategory entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MenuCategory>> ListActiveByRestaurantAsync(Guid restaurantGuid)
        {
            return await _dbContext.MenuCategories
                .Where(c => c.RestaurantGuid == restaurantGuid && c.Status == Domain.Enums.EStatus.Active)
                .ToListAsync();
        }

        public async Task<MenuCategory?> GetByNameAsync(string name, Guid restaurantGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return await _dbContext.MenuCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.Trim().ToLower()
                    && c.RestaurantGuid == restaurantGuid
                    && c.Status == Domain.Enums.EStatus.Active);
        }
    }
}
