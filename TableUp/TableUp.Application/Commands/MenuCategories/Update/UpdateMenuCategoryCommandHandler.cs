using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Update
{
    public class UpdateMenuCategoryCommandHandler : IRequestHandler<UpdateMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly UpdateMenuCategoryCommandValidator _validator;
        private readonly ICurrentUserService _currentUserService;

        public UpdateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository,
            UpdateMenuCategoryCommandValidator validator, ICurrentUserService currentUserService)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _validator = validator;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(UpdateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                string errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Failure(errors);
            }

            var category = await _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (category == null)
            {
                return Result.Failure("Categoria não encontrada.");
            }

            Guid userGuid = _currentUserService.UserId;
            category.Update(request.Name.Trim(), userGuid);
            await _menuCategoryRepository.UpdateAsync(category);

            return Result.Success("Categoria atualizada.");
        }
    }
}
