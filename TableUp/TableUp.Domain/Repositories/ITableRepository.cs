using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        Task<Table?> GetByNumberAsync(string tableNumber);
        Task<List<Table>> ListActiveByRestaurantAsync(Guid restaurantGuid);
    }
}
