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
        private static readonly List<MenuItem> _menuItems;

        // Static constructor to initialize the in-memory list with your sample data
        static MenuItemRepository()
        {
            var menuCategory = new MenuCategory("Main Course");
            menuCategory.Deactivate();
            var newCategory = new MenuCategory("Desserts");

            _menuItems = new List<MenuItem>
            {
                new MenuItem("Spaghetti Bolognese", "Classic Italian pasta with meat sauce", menuCategory.Guid, menuCategory, 12.99m),
                new MenuItem("Caesar Salad", "Crisp romaine lettuce with Caesar dressing", menuCategory.Guid, menuCategory, 8.99m),
                new MenuItem("Margherita Pizza", "Fresh tomatoes, mozzarella, and basil", menuCategory.Guid, menuCategory, 10.99m),
                new MenuItem("Tiramisu", "Coffee-flavored Italian dessert", newCategory.Guid, newCategory, 6.99m)
            };
        }

        public Task<MenuItem> AddAsync(MenuItem entity)
        {
            _menuItems.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(MenuItem entity)
        {
            _menuItems.Remove(entity);

            entity.Deactivate();

            _menuItems.Add(entity);

            return Task.CompletedTask;
        }

        public Task<MenuItem?> GetByIdAsync(Guid id)
        {
            var item = _menuItems.FirstOrDefault(c => c.Guid == id);
            return Task.FromResult(item);
        }

        public async Task<IReadOnlyList<MenuItem>> ListAllAsync(bool active)
        {
            if (active)
            {
                var activeItems = _menuItems.Where(c => c.Status == Domain.Enums.EStatus.Active)
                .Where(c => c.Category.Status == Domain.Enums.EStatus.Active)
                .ToList();
                return await Task.FromResult(activeItems.AsReadOnly());
            }

            return await Task.FromResult(_menuItems.AsReadOnly());
        }

        public Task UpdateAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
