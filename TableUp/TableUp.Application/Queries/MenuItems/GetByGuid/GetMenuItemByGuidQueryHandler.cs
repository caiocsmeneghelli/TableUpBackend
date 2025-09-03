using MediatR;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuItems.GetByGuid
{
    public class GetMenuItemByGuidQueryHandler : IRequestHandler<GetMenuItemByGuidQuery, MenuItemViewModel?>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public GetMenuItemByGuidQueryHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItemViewModel?> Handle(GetMenuItemByGuidQuery request, CancellationToken cancellationToken)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(request.Guid);
            if (menuItem == null)
            {
                return null;
            }

            var vm = new MenuItemViewModel();
            vm.FromModel(menuItem);
            return vm;
        }
    }
}