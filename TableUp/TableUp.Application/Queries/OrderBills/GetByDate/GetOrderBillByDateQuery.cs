using MediatR;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderBills.GetToday
{
    public class GetOrderBillByDateQuery : IRequest<List<OrderBillsViewModel>>
    {
        public DateTime DateTime { get; set; }
    }
}
