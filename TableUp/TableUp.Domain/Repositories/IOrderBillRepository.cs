using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface IOrderBillRepository : IRepository<OrderBill>
    {
        Task<List<OrderBill>> ListByDateAsync(DateTime dateTime);
    }
}