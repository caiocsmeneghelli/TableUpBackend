using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        Task<Table?> GetByNumberAsync(string tableNumber, Guid restaurantGuid);
        Task<List<Table>> ListActiveByRestaurantAsync(Guid restaurantGuid);
    }
}
