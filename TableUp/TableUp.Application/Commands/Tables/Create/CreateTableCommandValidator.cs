using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Create
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        private readonly ITableRepository _tableRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        public CreateTableCommandValidator(ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
        {
            _tableRepository = tableRepository;
            _restaurantRepository = restaurantRepository;

            RuleFor(x => x.TableNumber)
                .NotEmpty().WithMessage("O número da mesa é obrigatório.")
                .Length(1, 3).WithMessage("O número da mesa deve conter entre 1 e 3 caracteres.")
                .Matches(@"^\d+$").WithMessage("O número da mesa deve conter apenas dígitos.")
                .MustAsync((command, _, cancellationToken) => TableNumberMustBeUnique(command, cancellationToken)).WithMessage("Mesa {PropertyValue} já existe.");

            RuleFor(x => x.RestaurantGuid)
                .NotEmpty().WithMessage("O identificador do restaurante é obrigatório.");

            RuleFor(x => x.RestaurantGuid)
                .MustAsync(RestaurantGuidMustExistAndActive).WithMessage("Restaurante não encontrado ou inativo.");        
        }

        private async Task<bool> TableNumberMustBeUnique(CreateTableCommand command, CancellationToken cancellationToken)
        {
            var tableExists = await _tableRepository.GetByNumberAsync(command.TableNumber, command.RestaurantGuid);
            return tableExists == null;
        }

        private async Task<bool> RestaurantGuidMustExistAndActive(Guid restaurantGuid, CancellationToken cancellationToken)
        {
            var restaurantExists = await _restaurantRepository.GetByIdAsync(restaurantGuid);
            return restaurantExists != null && restaurantExists.Status == Domain.Enums.EStatus.Active;
        }
    }
}
