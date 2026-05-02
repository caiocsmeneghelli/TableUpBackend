using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.OrderBills.AddItem
{
    public class AddItemOrderBillCommandValidator : AbstractValidator<AddItemOrderBillCommand>
    {
        public AddItemOrderBillCommandValidator()
        {
            RuleFor(reg => reg.TableNumber)
                .NotEmpty().WithMessage("Table number is required.")
                .MaximumLength(3).WithMessage("Table number cannot exceed 3 characters.")
                .Matches(@"^\d+$").WithMessage("Table number must be numeric.");

            RuleFor(reg => reg.Items)
                .NotNull().WithMessage("Items list cannot be null.")
                .NotEmpty().WithMessage("At least one item must be provided.");

            RuleForEach(reg => reg.Items)
                .ChildRules(item =>
                {
                    item.RuleFor(i => i.MenuItemGuid)
                        .NotEmpty().WithMessage("MenuItem GUID cannot be empty.");

                    item.RuleFor(i => i.Quantity)
                        .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
                });
        }
    }
}
