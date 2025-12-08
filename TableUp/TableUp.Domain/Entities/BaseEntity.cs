using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Guid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public EStatus Status { get; private set; }

        public Guid CreatedByGuid { get; private set; }
        public User CreatedBy { get; private set; }
        public Guid UpdatedByGuid { get; private set; }
        public User UpdatedBy { get; private set; }

        public void Deactivate()
        {
            Status = EStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            Status = EStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUpdated(Guid userGuid)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedByGuid = userGuid;
        }

        public void SetCreated(Guid userGuid)
        {
            Guid = Guid.NewGuid();
            Status = EStatus.Active;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            CreatedByGuid = userGuid;
            UpdatedByGuid = userGuid;
        }
    }
}
