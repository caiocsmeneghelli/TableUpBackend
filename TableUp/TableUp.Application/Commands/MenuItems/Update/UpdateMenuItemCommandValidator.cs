using FluentValidation;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandValidator : AbstractValidator<UpdateMenuItemCommand>
    {
        public UpdateMenuItemCommandValidator()
        {
            RuleFor(x => x.Guid).NotEmpty().WithMessage("Guid is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Value must be greater than zero.");
            RuleFor(x => x.CategoryGuid)
                .NotEmpty().WithMessage("CategoryGuid is required.");
        }
    }
}
