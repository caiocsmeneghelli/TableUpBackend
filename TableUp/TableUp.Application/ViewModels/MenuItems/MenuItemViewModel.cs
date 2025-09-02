using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.MenuItems
{
    public class MenuItemViewModel
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public Guid CategoryGuid { get; private set; }
        public string CategoryName { get; private set; } = string.Empty;
        public EStatus Status { get; private set; }

        public void FromModel(MenuItem model)
        {
            Guid = model.Guid;
            Name = model.Name;
            Description = model.Description;
            Price = model.Value;
            CategoryGuid = model.CategoryGuid;
            CategoryName = model.Category != null ? model.Category.Name : string.Empty;
            Status = model.Status;
        }
    }
}
