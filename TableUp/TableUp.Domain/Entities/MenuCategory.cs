using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public string Name { get; private set; }
        public Guid RestaurantGuid { get; private set; }
        public Restaurant Restaurant { get; private set; }

        // EF Core constructor
        private MenuCategory()
        { }

        public MenuCategory(string name, Guid userGuid, Guid restaurantGuid)
        {
            Name = name;
            SetCreated(userGuid);
            RestaurantGuid = restaurantGuid;
        }
    }
}
