using MediatR;
using TableUp.Application.ViewModels.MenuCategories;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuCategories.GetAll
{
    public class GetAllMenuCategoriesQueryHandler : IRequestHandler<GetAllMenuCategoriesQuery, List<MenuCategoryViewModel>>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        public GetAllMenuCategoriesQueryHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<List<MenuCategoryViewModel>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _menuCategoryRepository.ListAllAsync(true);
            return categories
                .Select(c => new MenuCategoryViewModel(c))
                .ToList();
        }
    }
}
