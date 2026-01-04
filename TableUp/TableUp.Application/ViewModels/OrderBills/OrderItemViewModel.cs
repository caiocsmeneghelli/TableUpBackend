using System;
using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.OrderBills
{
    public class OrderItemViewModel
    {
        public Guid Guid { get; private set; }
        public int Quantity { get; private set; }
        public Guid GuidItemMenu { get; private set; }
        public string ItemMenuName { get; private set; } = string.Empty;
        public string CreatedByName { get; private set; } = string.Empty;

        public void FromEntity(OrderItem model)
        {   
            Guid = model.Guid;
            Quantity = model.Quantity;
            GuidItemMenu = model.MenuItemGuid;
            ItemMenuName = model.MenuItem?.Name ?? string.Empty;
            CreatedByName = model.CreatedBy?.Name ?? string.Empty;
        }
    }
}