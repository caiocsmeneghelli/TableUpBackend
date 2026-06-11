using MediatR;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderItems.GetAll
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItemViewModel>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetAllOrderItemsQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<OrderItemViewModel>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.ListAllAsync(request.Pending);
            return orderItems.Select(orderItem => new OrderItemViewModel(orderItem)).ToList();
        }
    }
}
