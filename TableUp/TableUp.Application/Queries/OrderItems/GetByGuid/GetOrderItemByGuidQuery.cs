using MediatR;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderItems.GetByGuid
{
    public class GetOrderItemByGuidQuery : IRequest<OrderItemViewModel?>
    {
        public Guid OrderItemGuid { get; set; }
    }
}
