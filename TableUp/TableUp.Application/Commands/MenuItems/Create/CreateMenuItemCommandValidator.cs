using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommandValidator : AbstractValidator<CreateMenuItemCommand>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public CreateMenuItemCommandValidator(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Descrição não pode exceder 500 caracteres.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Valor precisa ser maior que zero.");
            RuleFor(x => x.CategoryGuid)
                .NotEmpty().WithMessage("CategoryGuid é obrigatório.")
                .MustAsync(CategoryMustExistAndActive).WithMessage("Categoria não encontrada ou inativa.");
        }

        private async Task<bool> CategoryMustExistAndActive(Guid categoryGuid, CancellationToken cancellationToken)
        {
            var category = await _menuCategoryRepository.GetByIdAsync(categoryGuid);
            return category != null && category.Status == Domain.Enums.EStatus.Active;
        }
    }
}
