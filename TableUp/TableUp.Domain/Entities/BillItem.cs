namespace TableUp.Domain.Entities
{
    public class BillItem
    {
        public int Quantity { get; private set; }
        public Guid MenuItemGuid { get; private set; }
        public MenuItem MenuItem { get; private set; }
        public Guid OrderBillGuid { get; private set; }
        public OrderBill OrderBill { get; private set; }
    }
}