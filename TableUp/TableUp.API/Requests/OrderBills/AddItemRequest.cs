using TableUp.Application.Dtos;

namespace TableUp.API.Requests.OrderBills
{
    public class AddItemRequest
    {
        public Guid RestaurantGuid { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
