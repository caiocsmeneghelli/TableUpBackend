using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface IMenuCategoryRepository : IRepository<MenuCategory>
    {
        Task<List<MenuCategory>> ListActiveByRestaurantAsync(Guid restaurantGuid);
        Task<MenuCategory?> GetByNameAsync(string name, Guid restaurantGuid);
    }
}
