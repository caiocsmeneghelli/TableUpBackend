using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        public Task<MenuCategory> AddAsync(MenuCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MenuCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<MenuCategory> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MenuCategory>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MenuCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
