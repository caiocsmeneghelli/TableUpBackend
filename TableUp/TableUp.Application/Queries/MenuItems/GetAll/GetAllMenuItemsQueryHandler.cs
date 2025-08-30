using MediatR;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuItems.GetAll
{
    internal class GetAllMenuItemsQueryHandler : IRequestHandler<GetAllMenuItemsQuery, List<MenuItemViewModel>>
    {
        public Task<List<MenuItemViewModel>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var menuCategory = new MenuCategory("Main Course");

            var menuItems = new List<MenuItem>
            {
                new MenuItem( "Spaghetti Bolognese", "Classic Italian pasta with meat sauce", menuCategory, 12.99m ),
                new MenuItem( "Caesar Salad", "Crisp romaine lettuce with Caesar dressing", menuCategory, 8.99m ),
                new MenuItem( "Margherita Pizza", "Fresh tomatoes, mozzarella, and basil", menuCategory, 10.99m )
            };

            var newCategory = new MenuCategory("Desserts");
            menuItems.Add(new MenuItem("Tiramisu", "Coffee-flavored Italian dessert", newCategory, 6.99m));

            var menuVwItems = new List<MenuItemViewModel>();
            foreach (var item in menuItems)
            {
                var vwItem = new MenuItemViewModel();
                vwItem.FromModel(item);
                menuVwItems.Add(vwItem);
            }

            return Task.FromResult(menuVwItems);
        }
    }
}
