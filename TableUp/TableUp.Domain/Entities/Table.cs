using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string Number { get; private set; }

        public Table()
        { }
        public Table(Guid userGuid)
        {
            SetCreated(userGuid);
        }
    }
}
