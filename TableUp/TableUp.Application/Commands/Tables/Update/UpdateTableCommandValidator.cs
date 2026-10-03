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
                .MustAsync((command, _, cancellationToken) => TableNumberMustBeUnique(command, cancellationToken)).WithMessage("Mesa {PropertyValue} já existe.");

            RuleFor(x => x.RestaurantGuid)
                .NotEmpty().WithMessage("O identificador do restaurante é obrigatório.");
        }

        private async Task<bool> TableNumberMustBeUnique(UpdateTableCommand command, CancellationToken cancellationToken)
        {
            var existing = await _tableRepository.GetByNumberAsync(command.TableNumber, command.RestaurantGuid);
            return existing == null || existing.Guid == command.Guid;
        }
    }
}
