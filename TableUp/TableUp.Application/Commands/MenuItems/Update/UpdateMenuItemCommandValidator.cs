using FluentValidation;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandValidator : AbstractValidator<UpdateMenuItemCommand>
    {
        public UpdateMenuItemCommandValidator()
        {
            RuleFor(x => x.Guid).NotEmpty().WithMessage("Guid é obrigatório.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Descrição não pode exceder 500 caracteres.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Valor precisa ser maior que zero.");
            RuleFor(x => x.CategoryGuid)
                .NotEmpty().WithMessage("CategoryGuid é obrigatório.");
        }
    }
}
