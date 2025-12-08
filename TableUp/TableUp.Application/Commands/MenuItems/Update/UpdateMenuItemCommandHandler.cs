using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly UpdateMenuItemCommandValidator _validator;
        public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemRepository,
            IMenuCategoryRepository menuCategoryRepository, UpdateMenuItemCommandValidator validator, ICurrentUserService currentUserService)
        {
            _menuItemRepository = menuItemRepository;
            _menuCategoryRepository = menuCategoryRepository;
            _validator = validator;
            _currentUserService = currentUserService;
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

                Guid userGuid = _currentUserService.UserId;

                itemMenu.Update(request.Name, request.Description, request.CategoryGuid, request.Value, userGuid);
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
