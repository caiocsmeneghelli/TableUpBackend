using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.MenuItems
{
    public class MenuItemViewModel
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Value { get; private set; }
        public Guid CategoryGuid { get; private set; }
        public string CategoryName { get; private set; } = string.Empty;
        public Guid RestaurantGuid { get; private set; } = Guid.Empty;
        public string RestaurantName { get; private set; } = string.Empty;
        public EStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; } = string.Empty;

        public void FromModel(MenuItem model)
        {
            Guid = model.Guid;
            Name = model.Name;
            Description = model.Description;
            Value = model.Value;
            CategoryGuid = model.CategoryGuid;
            CategoryName = model.Category != null ? model.Category.Name : string.Empty;
            if (model.Category?.Restaurant is not null)
            {
                RestaurantGuid = model.Category.Restaurant.Guid;
                RestaurantName = model.Category.Restaurant.Name;
            }
            Status = model.Status;
            CreatedAt = model.CreatedAt;
            CreatedBy = model.CreatedBy?.Username ?? string.Empty;
        }
    }
}
