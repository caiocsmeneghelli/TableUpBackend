using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly CreateMenuItemCommandValidator _validator;

        public CreateMenuItemCommandHandler(IMenuItemRepository repository, CreateMenuItemCommandValidator validator,
            ICurrentUserService currentUserService)
        {
            _repository = repository;
            _validator = validator;
            _currentUserService = currentUserService;
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

            Guid userGuid = _currentUserService.UserId;
            request.UserGuid = userGuid;
            MenuItem menuItem = request.ToDomain();
            await _repository.AddAsync(menuItem);

            MenuItemViewModel vm = new MenuItemViewModel();
            vm.FromModel(menuItem);
            
            return Result.Success(vm);
        }
    }
}