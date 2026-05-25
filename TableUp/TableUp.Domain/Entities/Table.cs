namespace TableUp.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string Number { get; private set; }
        public string TableToken { get; private set; }
        public Guid RestaurantGuid { get; private set; }
        public Restaurant Restaurant { get; private set; }

        public Table()
        { }
        public Table(Guid userGuid, Guid restaurantGuid, string number)
        {
            Number = number;
            RestaurantGuid = restaurantGuid;
            TableToken = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            SetCreated(userGuid);
        }
    }
}
