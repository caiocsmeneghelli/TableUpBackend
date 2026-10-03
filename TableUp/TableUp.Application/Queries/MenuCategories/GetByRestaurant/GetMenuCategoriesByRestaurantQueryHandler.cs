using MediatR;
using TableUp.Application.ViewModels.MenuCategories;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuCategories.GetByRestaurant
{
    public class GetMenuCategoriesByRestaurantQueryHandler : IRequestHandler<GetMenuCategoriesByRestaurantQuery, List<MenuCategoryViewModel>>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public GetMenuCategoriesByRestaurantQueryHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<List<MenuCategoryViewModel>> Handle(GetMenuCategoriesByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var categories = await _menuCategoryRepository.ListActiveByRestaurantAsync(request.RestaurantGuid);
            return categories
                .OrderBy(c => c.Name)
                .Select(c => new MenuCategoryViewModel(c))
                .ToList();
        }
    }
}
