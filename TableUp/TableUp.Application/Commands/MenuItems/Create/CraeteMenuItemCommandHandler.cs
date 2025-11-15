using MediatR;
using TableUp.Application.Common;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _repository;
        private readonly CreateMenuItemCommandValidator _validator;

        public CreateMenuItemCommandHandler(IMenuItemRepository repository, CreateMenuItemCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join("; ", errors);
                return Result.Failure(errorMessage);
            }

            MenuItem menuItem = request.ToDomain();
            await _repository.AddAsync(menuItem);

            MenuItemViewModel vm = new MenuItemViewModel();
            vm.FromModel(menuItem);
            
            return Result.Success(vm);
        }
    }
}