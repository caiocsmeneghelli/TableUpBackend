using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Enums;

namespace TableUp.Application.Commands.OrderItems.ChangeStatus
{
    public class ChangeOrderItemStatusCommand : IRequest<Result>
    {
        public ChangeOrderItemStatusCommand(Guid guid, EStatusOrderItem status)
        {
            Guid = guid;
            Status = status;
        }

        public Guid Guid { get; set; }
        public EStatusOrderItem Status { get; set; }
    }
}
