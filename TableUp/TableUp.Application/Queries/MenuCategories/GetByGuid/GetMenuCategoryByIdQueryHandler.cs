using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (menuCategory == null)
            {
                return Task.FromResult<MenuCategoryViewModel>(null);
            }
            MenuCategoryViewModel menuCategoryViewModel = new MenuCategoryViewModel(menuCategory.Result.Guid, menuCategory.Result.Name);
            return Task.FromResult(menuCategoryViewModel);
        }
    }
}
