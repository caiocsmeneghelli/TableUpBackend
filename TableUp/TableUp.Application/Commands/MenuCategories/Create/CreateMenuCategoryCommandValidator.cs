using FluentValidation;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandValidator : AbstractValidator<CreateMenuCategoryCommand>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateMenuCategoryCommandValidator(IMenuCategoryRepository menuCategoryRepository, IRestaurantRepository restaurantRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _restaurantRepository = restaurantRepository;

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da categoria deve ter no máximo 100 caracteres.")
                .MustAsync((command, _, cancellationToken) => NameMustBeUnique(command, cancellationToken)).WithMessage("Categoria {PropertyValue} já existe.");

            RuleFor(r => r.RestaurantGuid)
                .NotEmpty().WithMessage("O identificador do restaurante é obrigatório.");

            RuleFor(r => r.RestaurantGuid)
                .MustAsync(RestaurantGuidMustExistAndActive).WithMessage("Restaurante não encontrado ou inativo.");
        }

        private async Task<bool> NameMustBeUnique(CreateMenuCategoryCommand command, CancellationToken cancellationToken)
        {
            var existing = await _menuCategoryRepository.GetByNameAsync(command.Name ?? string.Empty, command.RestaurantGuid);
            return existing == null;
        }

        private async Task<bool> RestaurantGuidMustExistAndActive(Guid restaurantGuid, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantGuid);
            return restaurant != null && restaurant.Status == Domain.Enums.EStatus.Active;
        }
    }
}
