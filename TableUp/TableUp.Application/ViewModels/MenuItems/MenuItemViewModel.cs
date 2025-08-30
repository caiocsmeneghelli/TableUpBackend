using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.MenuItems
{
    public class MenuItemViewModel
    {
        private Guid Guid { get; set; }
        private string Name { get; set; } = string.Empty;
        private string Description { get; set; } = string.Empty;
        private decimal Price { get; set; }
        private Guid CategoryGuid { get; set; }
        private string CategoryName { get; set; } = string.Empty;

        public void FromModel(MenuItem model)
        {
            Guid = model.Guid;
            Name = model.Name;
            Description = model.Description;
            Price = model.Value;
            CategoryGuid = model.Category.Guid;
            CategoryName = model.Category.Name;
        }
    }
}
