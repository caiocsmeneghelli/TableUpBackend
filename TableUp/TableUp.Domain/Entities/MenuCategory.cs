using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public string Name { get; private set; }
        public EStatus Status { get; private set; }

        public MenuCategory(string name)
        {
            Name = name;
            Status = EStatus.Active;
        }

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
