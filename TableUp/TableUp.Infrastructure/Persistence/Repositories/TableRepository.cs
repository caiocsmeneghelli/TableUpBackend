using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Infrastructure.Persistence.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly TableUpDbContext _dbContext;

        public TableRepository(TableUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Table> AddAsync(Table entity)
        {
            await _dbContext.Tables.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Table entity)
        {
            entity.Deactivate();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Table?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Tables.SingleOrDefaultAsync(reg => reg.Guid == id);
        }

        public async Task<List<Table>> ListAllAsync(bool active)
        {
            return await _dbContext.Tables.ToListAsync();
        }

        public async Task UpdateAsync(Table entity)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Table?> GetByNumberAsync(string tableNumber)
        {
            if (string.IsNullOrWhiteSpace(tableNumber))
                return null;

            return await _dbContext.Tables
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Number == tableNumber);
        }

    }
}
