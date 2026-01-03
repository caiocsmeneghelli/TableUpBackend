using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.OrderBills
{
    public class OrderBillsViewModel
    {
        public Guid GuidOrderBill { get; private set; }
        public string TableNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CratedBy { get; private set; }

        public EStatusOrderBill StatusOrderBill { get; private set; }

        public void FromEntity(OrderBill model)
        {
            GuidOrderBill = model.Guid;
            TableNumber = model.TableNumber;
            CreatedAt = model.CreatedAt.ToLocalTime();
            CratedBy = model.CreatedBy.Name;
            StatusOrderBill = model.StatusOrderBill;
        }
    }
}
