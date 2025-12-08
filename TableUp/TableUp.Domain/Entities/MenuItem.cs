namespace TableUp.Domain.Entities
{
    public class MenuItem : BaseEntity
    {
        public MenuItem(string name, string description, Guid categoryGuid, decimal value, Guid userGuid) : base(userGuid)
        {
            Name = name;
            Description = description;
            CategoryGuid = categoryGuid;
            Value = value;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryGuid { get; private set; }
        public MenuCategory Category { get; private set; }
        public decimal Value { get; private set; }

        //public string UrlImage { get; private set; }

        public void Update(string name, string description, Guid categoryGuid, decimal value, Guid userGuid)
        {
            Name = name;
            Description = description;
            CategoryGuid = categoryGuid;
            Value = value;

            SetUpdated(userGuid);
        }
    }
}
