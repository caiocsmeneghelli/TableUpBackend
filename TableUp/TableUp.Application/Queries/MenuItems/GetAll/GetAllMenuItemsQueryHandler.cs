using MediatR;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuItems.GetAll
{
    internal class GetAllMenuItemsQueryHandler : IRequestHandler<GetAllMenuItemsQuery, List<MenuItem>>
    {
        public Task<List<MenuItem>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var menuCategory = new MenuCategory("Main Course");

            var menuItems = new List<MenuItem>
            {
                new MenuItem( "Spaghetti Bolognese", "Classic Italian pasta with meat sauce", menuCategory, 12.99m ),
                new MenuItem( "Caesar Salad", "Crisp romaine lettuce with Caesar dressing", menuCategory, 8.99m ),
                new MenuItem( "Margherita Pizza", "Fresh tomatoes, mozzarella, and basil", menuCategory, 10.99m )
            };

            return Task.FromResult(menuItems);
        }
    }
}
