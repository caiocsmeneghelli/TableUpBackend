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
            var newCategory = new MenuCategory("Desserts");

            _menuItems = new List<MenuItem>
            {
                new MenuItem("Spaghetti Bolognese", "Classic Italian pasta with meat sauce", menuCategory, 12.99m),
                new MenuItem("Caesar Salad", "Crisp romaine lettuce with Caesar dressing", menuCategory, 8.99m),
                new MenuItem("Margherita Pizza", "Fresh tomatoes, mozzarella, and basil", menuCategory, 10.99m),
                new MenuItem("Tiramisu", "Coffee-flavored Italian dessert", newCategory, 6.99m)
            };
        }

        public Task<MenuItem> AddAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MenuItem>> ListAllAsync(bool active)
        {
            if (active)
            {
                var activeItems = _menuItems.Where(c => c.Status == Domain.Enums.EStatus.Active).ToList();
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
