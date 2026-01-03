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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TableUpDbContext _dbContext;

        public OrderItemRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItem> AddAsync(OrderItem entity)
        {
            await _dbContext.OrderItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(OrderItem entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(Guid id) => await _dbContext.OrderItems.SingleOrDefaultAsync(oi => oi.Guid == id);

        public async Task<List<OrderItem>> ListAllAsync(bool active)
        {
            if (active)
            {
                return await _dbContext.OrderItems.Where(oi => oi.Status == EStatus.Active).ToListAsync();
            }

            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
