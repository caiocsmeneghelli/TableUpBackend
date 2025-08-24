using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class FoodMenu : BaseEntity
    {
        public FoodMenu(string name, string description, FoodCategory category)
        {
            Name = name;
            Description = description;
            Category = category;
            Status = EStatus.Active;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public FoodCategory Category { get; private set; }
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
