using MediatR;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.Application.Queries.OrderItems.GetAll
{
    public class GetAllOrderItemsQuery : IRequest<List<OrderItemViewModel>>
    {
        public bool Pending { get; set; }

        public GetAllOrderItemsQuery(bool pending)
        {
            Pending = pending;
        }
    }
}
