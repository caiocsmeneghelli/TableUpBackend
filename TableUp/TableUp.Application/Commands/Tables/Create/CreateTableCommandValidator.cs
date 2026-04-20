using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Create
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        private readonly ITableRepository _tableRepository;
        public CreateTableCommandValidator(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;

            RuleFor(x => x.TableNumber)
                .NotEmpty().WithMessage("O número da mesa é obrigatório.")
                .Length(1, 3).WithMessage("O número da mesa deve conter entre 1 e 3 caracteres.")
                .Matches(@"^\d+$").WithMessage("O número da mesa deve conter apenas dígitos.")
                .MustAsync(TableNumberMustBeUnique).WithMessage("Mesa {PropertyValue} já existe.");
        }

        private async Task<bool> TableNumberMustBeUnique(string tableNumber, CancellationToken cancellationToken)
        {
            var tableExists = await _tableRepository.GetByNumberAsync(tableNumber);
            return tableExists == null;
        }
    }
}
