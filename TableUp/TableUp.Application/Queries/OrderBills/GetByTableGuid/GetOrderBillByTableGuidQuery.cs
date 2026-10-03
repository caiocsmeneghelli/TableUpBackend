using MediatR;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderBills.GetByTableGuid
{
    public class GetOrderBillByTableGuidQuery : IRequest<OrderBillsViewModel?>
    {
        public Guid TableGuid { get; set; }
    }
}
