using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Domain.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        Task<Table?> GetByNumberAsync(string tableNumber);
    }
}
