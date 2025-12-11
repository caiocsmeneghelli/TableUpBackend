using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class OrderBill : BaseEntity
    {
        public OrderBill()
        {
            StatusOrderBill = EStatusOrderBill.Opened;
            BillItems = new List<BillItem>();
        }
        public decimal Amount { get; set; }
        public List<BillItem> BillItems { get; private set; }
        public EStatusOrderBill StatusOrderBill { get; private set; }
    }
}