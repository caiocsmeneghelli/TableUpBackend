using MediatR;
using TableUp.Application.ViewModels.MenuCategories;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuCategories.GetMenuByRestaurant
{
    public class GetMenuByRestaurantQueryHandler : IRequestHandler<GetMenuByRestaurantQuery, List<MenuCategoryWithItemsViewModel>>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public GetMenuByRestaurantQueryHandler(IMenuCategoryRepository menuCategoryRepository, IMenuItemRepository menuItemRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<List<MenuCategoryWithItemsViewModel>> Handle(GetMenuByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var categories = await _menuCategoryRepository.ListActiveByRestaurantAsync(request.RestaurantGuid);
            var items = await _menuItemRepository.ListActiveByCategoriesAsync(categories.Select(c => c.Guid));
            var itemsByCategory = items.ToLookup(i => i.CategoryGuid);

            // Categorias sem itens ativos não aparecem no cardápio do cliente
            return categories
                .Where(c => itemsByCategory.Contains(c.Guid))
                .OrderBy(c => c.Name)
                .Select(c => new MenuCategoryWithItemsViewModel(c, itemsByCategory[c.Guid]))
                .ToList();
        }
    }
}
