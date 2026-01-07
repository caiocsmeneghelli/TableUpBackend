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
            RuleFor(reg => reg.GuidOrderBill)
                .NotEmpty().WithMessage("Guid de conta não pode ser vazio.")
                .NotEqual(Guid.Empty).WithMessage("Guid de conta inválido");
            RuleFor(reg => reg.GuidMenuItem)
                .NotEmpty().WithMessage("Guid de item não pode ser vazio.")
                .NotEqual(Guid.Empty).WithMessage("Guid de item inválido");
            RuleFor(reg => reg.Quantity)
                .NotEmpty().WithMessage("Quantidade não pode ser vazio.")
                .NotEqual(0).WithMessage("Quantidade precisa ser maior que zero.");
        }
    }
}
