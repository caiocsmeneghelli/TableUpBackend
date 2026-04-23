using MediatR;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderBills.GetByTableNumber
{
    public class GetOrderBillByTableNumberQueryHandler : IRequestHandler<GetOrderBillByTableNumberQuery, OrderBillsViewModel?>
    {
        private readonly IOrderBillRepository _orderBillRepository;

        public GetOrderBillByTableNumberQueryHandler(IOrderBillRepository orderBillRepository)
        {
            _orderBillRepository = orderBillRepository;
        }

        public async Task<OrderBillsViewModel?> Handle(GetOrderBillByTableNumberQuery request, CancellationToken cancellationToken)
        {
            var orderBill = await _orderBillRepository.GetByTableNumberAsync(request.TableNumber);
            if (orderBill is null) { return null; }
            OrderBillsViewModel viewModel = new();
            viewModel.FromEntity(orderBill);
            return viewModel;
        }
    }
}
