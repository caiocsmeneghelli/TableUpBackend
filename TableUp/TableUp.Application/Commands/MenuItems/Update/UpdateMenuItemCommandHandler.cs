using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemRepository, IMenuCategoryRepository menuCategoryRepository)
        {
            _menuItemRepository = menuItemRepository;
            _menuCategoryRepository = menuCategoryRepository;
        }
        public async Task<Result> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemMenu = await _menuItemRepository.GetByIdAsync(request.Guid);
                if (itemMenu == null) return Result.Failure("Menu item não encontrado") ;

                var itemCategory = await _menuCategoryRepository.GetByIdAsync(request.CategoryGuid);
                if (itemCategory == null || itemCategory.Status != Domain.Enums.EStatus.Active) return Result.Failure("Menu item desativado");

                itemMenu.Update(request.Name, request.Description, request.CategoryGuid, request.Value);
                await _menuItemRepository.UpdateAsync(itemMenu);
                return Result.Success(itemMenu);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
