using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommandValidator : AbstractValidator<CreateMenuItemCommand>
    {
        public CreateMenuItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Descrição não pode exceder 500 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Preço precisa ser maior que 0.");
            RuleFor(x => x.CategoryGuid)
                .NotEmpty().WithMessage("CategoryGuid é obrigatório.");
        }
    }
}
