using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.MenuCategories
{
    public class MenuCategoryViewModel
    {
        public MenuCategoryViewModel(Guid guid, string name, EStatus status, Restaurant restaurant)
        {
            Guid = guid;
            Name = name;
            Status = status;
            if(restaurant is not null)
            {
                RestaurantGuid = restaurant.Guid;
                RestaurantName = restaurant.Name;
            }
        }

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public EStatus Status { get; private set; }
        public Guid RestaurantGuid { get; private set; } = Guid.Empty;
        public string RestaurantName { get; private set; } = string.Empty;
    }
}
