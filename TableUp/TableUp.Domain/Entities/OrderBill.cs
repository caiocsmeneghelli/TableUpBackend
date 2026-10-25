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
        public Guid TableGuid { get; private set; }

        // Itens cancelados não entram no valor da conta
        public decimal Total => BillItems?
            .Where(item => item.StatusOrderItem != EStatusOrderItem.Canceled)
            .Sum(item => item.Quantity * (item.MenuItem?.Value ?? 0m)) ?? 0m;

        private void SetTable(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table), "A mesa n�o pode ser nula.");
            
            TableGuid = table.Guid;
        }

        public bool CanClose => StatusOrderBill == EStatusOrderBill.Opened;
        public bool CanCancel => StatusOrderBill is EStatusOrderBill.Opened or EStatusOrderBill.Closed;
        public bool CanPay => StatusOrderBill == EStatusOrderBill.Closed;

        public void CloseBill(Guid userGuid)
        {
            // Ao finalizar a conta, os itens ainda em preparo são cancelados
            CancelPendingItems(userGuid);

            StatusOrderBill = EStatusOrderBill.Closed;
            base.Deactivate(userGuid);
        }

        public void Deactivate(Guid userGuid)
        {
            // Conta cancelada não deve deixar itens pendentes na cozinha
            CancelPendingItems(userGuid);

            StatusOrderBill = EStatusOrderBill.Canceled;
            base.Deactivate(userGuid);
        }

        public void Pay(Guid userGuid)
        {
            StatusOrderBill = EStatusOrderBill.Paid;
            SetUpdated(userGuid);
        }

        private void CancelPendingItems(Guid userGuid)
        {
            foreach (var item in BillItems?.Where(item => item.StatusOrderItem == EStatusOrderItem.Pending) ?? [])
            {
                item.CancelOrderItem(userGuid);
            }
        }
    }
}