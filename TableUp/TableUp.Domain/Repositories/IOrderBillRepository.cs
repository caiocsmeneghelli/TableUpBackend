using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface IOrderBillRepository : IRepository<OrderBill>
    {
        Task<List<OrderBill>> ListByDateAsync(DateTime dateTime);
        Task<OrderBill?> GetByTableNumberAsync(string tableNumber, Guid restaurantGuid);
        Task<OrderBill?> GetActiveByTableGuidAsync(Guid tableGuid);
        Task<List<OrderBill>> ListActiveByTablesAsync(IEnumerable<Guid> tableGuids);
    }
}