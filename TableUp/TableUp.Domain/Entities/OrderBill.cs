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

            SetTableNumber(tableNumber);
            SetCreated(guidUser);
        }
        public decimal Amount { get; set; }
        public List<OrderItem> BillItems { get; private set; }
        public EStatusOrderBill StatusOrderBill { get; private set; }
        public string TableNumber { get; private set; }

        private void SetTableNumber(string tableNumber)
        {
            if (string.IsNullOrWhiteSpace(tableNumber))
                throw new ArgumentException("Código é obrigatório.");

            if (!tableNumber.All(char.IsDigit))
                throw new ArgumentException("Código deve conter apenas números.");

            TableNumber = tableNumber.PadLeft(3, '0');
        }

        public void CloseBill(Guid userGuid)
        {
            StatusOrderBill = EStatusOrderBill.Closed;
            SetUpdated(userGuid);
        }

        public void Deactivate(Guid userGuid)
        {
            StatusOrderBill = EStatusOrderBill.Canceled;
            Deactivate();
            SetUpdated(userGuid);
        }
    }
}