namespace TableUp.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        { }

        public OrderItem(decimal quantity, Guid menuItemGuid, Guid orderBillGuid, Guid userGuid)
        {
            Quantity = (int)quantity;
            MenuItemGuid = menuItemGuid;
            OrderBillGuid = orderBillGuid;

            SetCreated(userGuid);
        }

        public int Quantity { get; private set; }
        public Guid MenuItemGuid { get; private set; }
        public MenuItem MenuItem { get; private set; }
        public Guid OrderBillGuid { get; private set; }
        public OrderBill OrderBill { get; private set; }
    }
}