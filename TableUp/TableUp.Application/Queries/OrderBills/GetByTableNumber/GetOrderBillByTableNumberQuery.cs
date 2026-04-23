using MediatR;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderBills.GetByTableNumber
{
    public class GetOrderBillByTableNumberQuery : IRequest<OrderBillsViewModel?>
    {
        public string TableNumber { get; set; } = string.Empty;
    }
}
