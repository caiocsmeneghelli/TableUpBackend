using MediatR;
using TableUp.Application.ViewModels.MenuCategories;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuCategories.GetByGuid
{
    public class GetMenuCategoryByIdQueryHandler : IRequestHandler<GetMenuCategoryByGuidQuery, MenuCategoryViewModel>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public GetMenuCategoryByIdQueryHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<MenuCategoryViewModel> Handle(GetMenuCategoryByGuidQuery request, CancellationToken cancellationToken)
        {
            var menuCategory = await _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (menuCategory == null)
            {
                return null;
            }
            return new MenuCategoryViewModel(menuCategory.Guid, 
                menuCategory.Name, menuCategory.Status, menuCategory.Restaurant);
        }
    }
}
