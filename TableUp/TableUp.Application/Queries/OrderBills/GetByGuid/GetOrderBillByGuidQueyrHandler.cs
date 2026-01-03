using MediatR;
using TableUp.Application.Common;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderBills.GetByGuid
{
    public class GetOrderBillByGuidQueyrHandler : IRequestHandler<GetOrderBillByGuidQuery, OrderBillsViewModel?>
    {
        private readonly IOrderBillRepository _orderBillRepository;

        public GetOrderBillByGuidQueyrHandler(IOrderBillRepository orderBillRepository)
        {
            _orderBillRepository = orderBillRepository;
        }

        public async Task<OrderBillsViewModel?> Handle(GetOrderBillByGuidQuery request, CancellationToken cancellationToken)
        {
            OrderBill? orderBill = await _orderBillRepository.GetByIdAsync(request.Guid);
            if(orderBill == null)
            {
                return null;
            }

            var vm = new OrderBillsViewModel();
            vm.FromEntity(orderBill);
            return vm;
        }
    }
}
