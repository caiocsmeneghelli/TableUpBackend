using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Infrastructure.Persistence
{
    public class TableUpDbContext(DbContextOptions<TableUpDbContext> options) : DbContext(options)
    {
    }
}
