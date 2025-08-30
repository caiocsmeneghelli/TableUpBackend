using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Guid = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Guid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        //public Guid CreatedBy { get; private set; }
        //public Guid UpdatedBy { get; private set; }
    }
}
