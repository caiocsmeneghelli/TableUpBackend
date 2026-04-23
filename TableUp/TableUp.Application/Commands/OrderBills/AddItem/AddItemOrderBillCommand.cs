using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Dtos;

namespace TableUp.Application.Commands.OrderBills.AddItem
{
    public class AddItemOrderBillCommand : IRequest<Result>
    {
        public string TableNumber { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
