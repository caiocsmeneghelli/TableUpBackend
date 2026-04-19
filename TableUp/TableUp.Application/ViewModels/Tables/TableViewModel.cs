using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.Tables
{
    public class TableViewModel
    {
        public Guid TableGuid { get; private set; }
        public string TableNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }

        public TableViewModel(Table table)
        {
            TableGuid = table.Guid;
            TableNumber = table.Number;
            CreatedAt = table.CreatedAt;
            CreatedBy = table.CreatedBy.Username;
        }
    }
}
