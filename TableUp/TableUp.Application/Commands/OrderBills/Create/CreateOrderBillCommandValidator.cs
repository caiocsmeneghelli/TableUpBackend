using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.OrderBills.Create
{
    public class CreateOrderBillCommandValidator : AbstractValidator<CreateOrderBillCommand>
    {
        public CreateOrderBillCommandValidator()
        {
            RuleFor(x => x.TableNumber)
                .NotEmpty().WithMessage("Table number is required.")
                .MaximumLength(3).WithMessage("Table number cannot exceed 3 characters.")
                .Matches(@"^\d+$").WithMessage("O campo Código deve conter apenas números.");
        }
    }
}
