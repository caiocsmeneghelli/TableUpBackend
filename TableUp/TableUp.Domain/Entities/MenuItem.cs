using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class MenuItem : BaseEntity
    {
        public MenuItem(string name, string description, MenuCategory category)
        {
            Name = name;
            Description = description;
            Category = category;
            Status = EStatus.Active;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public MenuCategory Category { get; private set; }
        public EStatus Status { get; private set; }
        //public string UrlImage { get; private set; }

        public void Deactivate()
        {
            Status = EStatus.Inactive;
        }

        public void Activate()
        {
            Status = EStatus.Active;
        }
    }
}
