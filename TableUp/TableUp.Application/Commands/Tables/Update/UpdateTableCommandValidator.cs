using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Update
{
    public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        private readonly ITableRepository _tableRepository;

        public UpdateTableCommandValidator(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;

            RuleFor(x => x.TableNumber)
                .NotEmpty().WithMessage("O número da mesa é obrigatório.")
                .Length(1, 3).WithMessage("O número da mesa deve conter entre 1 e 3 caracteres.")
                .Matches(@"^\d+$").WithMessage("O número da mesa deve conter apenas dígitos.")
                .MustAsync(TableNumberMustBeUnique).WithMessage("Mesa {PropertyValue} já existe.");
        }

        private async Task<bool> TableNumberMustBeUnique(UpdateTableCommand command, string tableNumber, CancellationToken cancellationToken)
        {
            var existing = await _tableRepository.GetByNumberAsync(tableNumber);
            return existing == null || existing.Guid == command.Guid;
        }
    }
}
