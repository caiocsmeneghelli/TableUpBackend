using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.MenuCategories
{
    public class MenuCategoryViewModel
    {
        public MenuCategoryViewModel(MenuCategory category)
        {
            Guid = category.Guid;
            Name = category.Name;
            Status = category.Status;
            CreatedAt = category.CreatedAt;
            CreatedBy = category.CreatedBy?.Username ?? string.Empty;
            if (category.Restaurant is not null)
            {
                RestaurantGuid = category.Restaurant.Guid;
                RestaurantName = category.Restaurant.Name;
            }
        }

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public EStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public Guid RestaurantGuid { get; private set; } = Guid.Empty;
        public string RestaurantName { get; private set; } = string.Empty;
    }
}
