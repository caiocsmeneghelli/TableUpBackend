using MediatR;
using TableUp.Application.ViewModels.MenuCategories;

namespace TableUp.Application.Queries.MenuCategories.GetByRestaurant
{
    public class GetMenuCategoriesByRestaurantQuery : IRequest<List<MenuCategoryViewModel>>
    {
        public Guid RestaurantGuid { get; set; }
    }
}
