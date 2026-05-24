using Microsoft.EntityFrameworkCore;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly TableUpDbContext _context;

        public RestaurantRepository(TableUpDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> AddAsync(Restaurant entity)
        {
            await _context.Restaurants.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Restaurant entity)
        {
            entity.Deactivate();
            await UpdateAsync(entity);
        }

        public async Task<Restaurant?> GetByIdAsync(Guid id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task<List<Restaurant>> ListAllAsync(bool active)
        {
            if (active)
            {
                return await _context.Restaurants.Where(r => r.Status == Domain.Enums.EStatus.Active)
                    .ToListAsync();
            }

            return await _context.Restaurants.ToListAsync();
        }

        public async Task UpdateAsync(Restaurant entity)
        {
            _context.Restaurants.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
