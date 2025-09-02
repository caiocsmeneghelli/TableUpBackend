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
        public Task<List<MenuCategoryViewModel>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _menuCategoryRepository.ListAllAsync(false);
            var viewModels = categories.Result.Select(c => new MenuCategoryViewModel(c.Guid, c.Name)).ToList();
            return Task.FromResult(viewModels);
        }
    }
}
