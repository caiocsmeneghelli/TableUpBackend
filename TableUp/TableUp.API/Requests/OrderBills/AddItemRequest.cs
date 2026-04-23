using TableUp.Application.Dtos;

namespace TableUp.API.Requests.OrderBills
{
    public class AddItemRequest
    {
        public List<OrderItemDto> Items { get; set; }
    }
}
