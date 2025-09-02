using System.Collections.ObjectModel;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private static readonly List<MenuCategory> _menuCategories = new();
        static MenuCategoryRepository()
        {
            _menuCategories.Add(new MenuCategory("Main Course"));
            _menuCategories.Add(new MenuCategory("Desserts"));
        }

        public Task<MenuCategory> AddAsync(MenuCategory entity)
        {
            _menuCategories.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(MenuCategory entity)
        {
            _menuCategories.Remove(entity);

            entity.Deactivate();

            _menuCategories.Add(entity);

            return Task.CompletedTask;
        }

        public Task<MenuCategory?> GetByIdAsync(Guid id)
        {
            var category = _menuCategories.FirstOrDefault(c => c.Guid == id);
            return Task.FromResult(category);
        }

        public Task<IReadOnlyList<MenuCategory>> ListAllAsync(bool active)
        {
            if (active)
            {
                var activeCategories = _menuCategories.Where(c => c.Status == Domain.Enums.EStatus.Active).ToList();
                return Task.FromResult<IReadOnlyList<MenuCategory>>(new ReadOnlyCollection<MenuCategory>(activeCategories));
            }

            return Task.FromResult<IReadOnlyList<MenuCategory>>(new ReadOnlyCollection<MenuCategory>(_menuCategories));
        }

        public Task UpdateAsync(MenuCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
