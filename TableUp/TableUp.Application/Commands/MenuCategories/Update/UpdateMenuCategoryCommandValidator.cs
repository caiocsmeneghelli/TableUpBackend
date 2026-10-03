using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Update
{
    public class UpdateMenuCategoryCommandValidator : AbstractValidator<UpdateMenuCategoryCommand>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public UpdateMenuCategoryCommandValidator(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da categoria deve ter no máximo 100 caracteres.")
                .MustAsync((command, _, cancellationToken) => NameMustBeUnique(command, cancellationToken)).WithMessage("Categoria {PropertyValue} já existe.");

            RuleFor(x => x.RestaurantGuid)
                .NotEmpty().WithMessage("O identificador do restaurante é obrigatório.");
        }

        private async Task<bool> NameMustBeUnique(UpdateMenuCategoryCommand command, CancellationToken cancellationToken)
        {
            var existing = await _menuCategoryRepository.GetByNameAsync(command.Name, command.RestaurantGuid);
            return existing == null || existing.Guid == command.Guid;
        }
    }
}
