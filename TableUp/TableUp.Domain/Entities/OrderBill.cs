using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class OrderBill : BaseEntity
    {
        public OrderBill()
        { }
        public OrderBill(string tableNumber, Guid guidUser)
        {
            StatusOrderBill = EStatusOrderBill.Opened;
            BillItems = new List<OrderItem>();
            TableNumber = tableNumber;

            SetCreated(guidUser);
        }
        public decimal Amount { get; set; }
        public List<OrderItem> BillItems { get; private set; }
        public EStatusOrderBill StatusOrderBill { get; private set; }
        public string TableNumber { get; private set; }
    }
}