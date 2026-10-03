using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Inactive
{
    public class InactiveMenuCategoryCommandHandler : IRequestHandler<InactiveMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ICurrentUserService _currentUserService;

        public InactiveMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository,
            IMenuItemRepository menuItemRepository, ICurrentUserService currentUserService)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _menuItemRepository = menuItemRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(InactiveMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (category == null)
            {
                return Result.Failure("Categoria não encontrada.");
            }

            Guid userGuid = _currentUserService.UserId;
            category.Deactivate(userGuid);
            await _menuCategoryRepository.UpdateAsync(category);

            var menuItems = await _menuItemRepository.ListActiveByCategoriesAsync(new[] { category.Guid });
            foreach (var menuItem in menuItems)
            {
                menuItem.Deactivate(userGuid);
                await _menuItemRepository.UpdateAsync(menuItem);
            }

            return Result.Success("Categoria inativada.");
        }
    }
}
