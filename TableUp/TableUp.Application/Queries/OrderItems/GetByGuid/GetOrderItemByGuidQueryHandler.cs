using MediatR;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderItems.GetByGuid
{
    public class GetOrderItemByGuidQueryHandler : IRequestHandler<GetOrderItemByGuidQuery, OrderItemViewModel?>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemByGuidQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItemViewModel?> Handle(GetOrderItemByGuidQuery request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemGuid);
            if (orderItem is null)
                return null;

            return new OrderItemViewModel(orderItem);
        }
    }
}
