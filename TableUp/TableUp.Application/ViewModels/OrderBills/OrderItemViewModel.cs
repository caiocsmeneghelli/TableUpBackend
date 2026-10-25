using System;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.OrderBills
{
    public class OrderItemViewModel
    {
        public Guid Guid { get; private set; }
        public int Quantity { get; private set; }
        public Guid GuidItemMenu { get; private set; }
        public string ItemMenuName { get; private set; } = string.Empty;
        public string CreatedByName { get; private set; } = string.Empty;
        public decimal UnitValue { get; private set; }
        public decimal Total { get; private set; }
        public EStatusOrderItem StatusOrderItem { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public OrderItemViewModel(OrderItem model)
        {   
            Guid = model.Guid;
            Quantity = model.Quantity;
            GuidItemMenu = model.MenuItemGuid;
            ItemMenuName = model.MenuItem?.Name ?? string.Empty;
            CreatedByName = model.CreatedBy?.Name ?? string.Empty;
            UnitValue = model.MenuItem?.Value ?? 0m;
            Total = Quantity * UnitValue;
            StatusOrderItem = model.StatusOrderItem;
            CreatedAt = model.CreatedAt;
        }
    }
}