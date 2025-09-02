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

        public Task<MenuCategoryViewModel> Handle(GetMenuCategoryByGuidQuery request, CancellationToken cancellationToken)
        {
            var menuCategory = _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (menuCategory.Result == null)
            {
                return Task.FromResult<MenuCategoryViewModel>(null);
            }
            MenuCategoryViewModel menuCategoryViewModel = new MenuCategoryViewModel(menuCategory.Result.Guid, menuCategory.Result.Name, menuCategory.Result.Status);
            return Task.FromResult(menuCategoryViewModel);
        }
    }
}
