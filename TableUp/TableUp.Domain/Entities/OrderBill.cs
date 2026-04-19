using System;
using System.Collections.Generic;
using System.Linq;
using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class OrderBill : BaseEntity
    {
        public OrderBill()
        { }
        public OrderBill(Table table, Guid guidUser)
        {
            StatusOrderBill = EStatusOrderBill.Opened;
            BillItems = new List<OrderItem>();

            SetTable(table);
            SetCreated(guidUser);
        }
        public decimal Amount { get; set; }
        public List<OrderItem> BillItems { get; private set; }
        public EStatusOrderBill StatusOrderBill { get; private set; }
        public Table Table { get; private set; }

        public decimal Total => BillItems?.Sum(item => item.Quantity * (item.MenuItem?.Value ?? 0m)) ?? 0m;

        private void SetTable(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table), "A mesa não pode ser nula.");
            Table = table;
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