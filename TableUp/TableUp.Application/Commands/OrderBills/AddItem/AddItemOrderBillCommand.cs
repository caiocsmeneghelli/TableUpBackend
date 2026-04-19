using MediatR;
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
