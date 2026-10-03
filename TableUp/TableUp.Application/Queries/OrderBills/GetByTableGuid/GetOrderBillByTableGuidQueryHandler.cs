using MediatR;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderBills.GetByTableGuid
{
    public class GetOrderBillByTableGuidQueryHandler : IRequestHandler<GetOrderBillByTableGuidQuery, OrderBillsViewModel?>
    {
        private readonly IOrderBillRepository _orderBillRepository;

        public GetOrderBillByTableGuidQueryHandler(IOrderBillRepository orderBillRepository)
        {
            _orderBillRepository = orderBillRepository;
        }

        public async Task<OrderBillsViewModel?> Handle(GetOrderBillByTableGuidQuery request, CancellationToken cancellationToken)
        {
            var orderBill = await _orderBillRepository.GetActiveByTableGuidAsync(request.TableGuid);
            if (orderBill is null) { return null; }
            OrderBillsViewModel viewModel = new();
            viewModel.FromEntity(orderBill);
            return viewModel;
        }
    }
}
