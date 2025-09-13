using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly UpdateMenuItemCommandValidator _validator;
        public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemRepository, 
            IMenuCategoryRepository menuCategoryRepository, UpdateMenuItemCommandValidator validator)
        {
            _menuItemRepository = menuItemRepository;
            _menuCategoryRepository = menuCategoryRepository;
            _validator = validator;
        }
        public async Task<Result> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    string errorMessage = string.Join("; ", errors);
                    return Result.Failure(errorMessage);
                }


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
