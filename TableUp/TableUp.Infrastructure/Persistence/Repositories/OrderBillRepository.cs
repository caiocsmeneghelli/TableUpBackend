using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class OrderBillRepository : IOrderBillRepository
    {
        private readonly TableUpDbContext _dbContext;

        public OrderBillRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderBill> AddAsync(OrderBill entity)
        {
            await _dbContext.OrderBills.AddAsync(entity);
            await  _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(OrderBill entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderBill?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderBill>> ListAllAsync(bool active)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderBill entity)
        {
            throw new NotImplementedException();
        }
    }
}
