using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public string Name { get; private set; }

        // EF Core constructor
        private MenuCategory()
        { }

        public MenuCategory(string name, Guid userGuid)
        {
            Name = name;
            SetCreated(userGuid);
        }
    }
}
