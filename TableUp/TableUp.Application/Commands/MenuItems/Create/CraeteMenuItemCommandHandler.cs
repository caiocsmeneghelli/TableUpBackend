using MediatR;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, MenuItemViewModel>
    {
        private readonly IMenuItemRepository _repository;

        public CreateMenuItemCommandHandler(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public Task<MenuItemViewModel> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = new MenuItem(
                request.Name,
                request.Description,
                request.CategoryGuid,
                request.Price
            );

            _repository.AddAsync(menuItem);

            MenuItemViewModel vm = new MenuItemViewModel();
            vm.FromModel(menuItem);
            return Task.FromResult(vm);
        }
    }
}