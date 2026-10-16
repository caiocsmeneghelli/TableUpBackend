using MediatR;
using TableUp.Application.ViewModels.MenuCategories;

namespace TableUp.Application.Queries.MenuCategories.GetMenuByRestaurant
{
    public class GetMenuByRestaurantQuery : IRequest<List<MenuCategoryWithItemsViewModel>>
    {
        public Guid RestaurantGuid { get; set; }
    }
}
