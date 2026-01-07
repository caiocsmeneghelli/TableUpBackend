using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;
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

        public async Task DeleteAsync(OrderBill entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public Task<OrderBill?> GetByIdAsync(Guid id)
        {
            return _dbContext.OrderBills
                .Include(reg => reg.CreatedBy)
                .Include(reg => reg.UpdatedBy)
                .SingleOrDefaultAsync(ob => ob.Guid == id);
        }

        public Task<List<OrderBill>> ListAllAsync(bool active)
        {
            var query = _dbContext.OrderBills
                .Include(reg => reg.CreatedBy)
                .Include(reg => reg.UpdatedBy)
                .Include(reg => reg.BillItems)
                    .ThenInclude(oi => oi.MenuItem);

            if (active)
            {
                return query.Where(reg => reg.Status == EStatus.Active).ToListAsync();
            }

            return query.ToListAsync();
        }

        public async Task<List<OrderBill>> ListByDateAsync(DateTime dateTime)
        {
            var startDate = dateTime.Date;
            var endDate = startDate.AddDays(1);
            return await _dbContext.OrderBills
                .Where(ob => ob.CreatedAt >= startDate && ob.CreatedAt < endDate)
                .Include(reg => reg.CreatedBy)
                .Include(reg => reg.UpdatedBy)
                .Include(reg => reg.UpdatedBy)
                .Include(reg => reg.BillItems)
                    .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }

        public async Task UpdateAsync(OrderBill entity)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
