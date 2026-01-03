using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Enums;

namespace TableUp.Application.Commands.OrderBills.Close
{
    public class CloseCancelOrderBillCommand : IRequest<Result>
    {
        public CloseCancelOrderBillCommand(Guid guid, EStatusOrderBill status)
        {
            Guid = guid;
            Status = status;
        }

        public Guid Guid { get; set; }
        public EStatusOrderBill Status { get; set; }
    }
}
