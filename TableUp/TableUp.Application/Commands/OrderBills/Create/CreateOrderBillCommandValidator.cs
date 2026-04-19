using FluentValidation;

namespace TableUp.Application.Commands.OrderBills.Create
{
    public class CreateOrderBillCommandValidator : AbstractValidator<CreateOrderBillCommand>
    {
        public CreateOrderBillCommandValidator()
        {
            // Regra: deve existir TableNumber OU TableGuid
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.TableNumber) || x.TableGuid != Guid.Empty)
                .WithMessage("Informe TableNumber ou TableGuid.");

            // Quando tiver TableNumber, aplica validação atual
            When(x => !string.IsNullOrEmpty(x.TableNumber), () =>
            {
                RuleFor(x => x.TableNumber)
                    .MaximumLength(3).WithMessage("Table number cannot exceed 3 characters.")
                    .Matches(@"^\d+$").WithMessage("O campo Código deve conter apenas números.");
            });
        }
    }
}
