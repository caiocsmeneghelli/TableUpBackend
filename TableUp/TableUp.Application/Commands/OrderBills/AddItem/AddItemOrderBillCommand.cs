using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.OrderBills.AddItem
{
    public class AddItemOrderBillCommand : IRequest<Result>
    {
        public Guid GuidOrderBill { get; set; }
        public Guid GuidMenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
