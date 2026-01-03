using MediatR;
using TableUp.Application.Common;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderBills.GetByGuid
{
    public class GetOrderBillByGuidQuery : IRequest<OrderBillsViewModel?>
    {
        public Guid Guid { get; set; }

        public GetOrderBillByGuidQuery(Guid guid)
        {
            Guid = guid;
        }
    }
}
