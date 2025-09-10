using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandValidator : AbstractValidator<CreateMenuCategoryCommand>
    {
        public CreateMenuCategoryCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da categoria deve ter no máximo 100 caracteres.");
        }
    }
}
