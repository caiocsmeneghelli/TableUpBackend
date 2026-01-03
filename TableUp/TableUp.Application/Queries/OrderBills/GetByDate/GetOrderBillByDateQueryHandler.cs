using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Queries.OrderBills.GetToday;
using TableUp.Application.ViewModels.OrderBills;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.OrderBills.GetByDate
{
    public class GetOrderBillByDateQueryHandler : IRequestHandler<GetOrderBillByDateQuery, List<OrderBillsViewModel>>
    {
        private readonly IOrderBillRepository _orderBillRepository;

        public GetOrderBillByDateQueryHandler(IOrderBillRepository orderBillRepository)
        {
            _orderBillRepository = orderBillRepository;
        }

        public async Task<List<OrderBillsViewModel>> Handle(GetOrderBillByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderBillRepository.ListByDateAsync(request.DateTime);
            var listVw = new List<OrderBillsViewModel>();

            foreach(var item in result)
            {
                var vm = new OrderBillsViewModel();
                vm.FromEntity(item);

                listVw.Add(vm);
            }

            return listVw;
        }
    }
}
