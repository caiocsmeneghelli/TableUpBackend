using MediatR;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuItems.GetAllActive
{
    public class GetAllMenuItemActiveQueryHandler : IRequestHandler<GetAllMenuItemActiveQuery, List<MenuItemViewModel>>
    {
        private readonly IMenuItemRepository _repository;

        public GetAllMenuItemActiveQueryHandler(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MenuItemViewModel>> Handle(GetAllMenuItemActiveQuery request, CancellationToken cancellationToken)
        {
            var menuItems = await _repository.ListAllAsync(true);
            var menuVwItems = new List<MenuItemViewModel>();
            foreach (var item in menuItems)
            {
                var vwItem = new MenuItemViewModel();
                vwItem.FromModel(item);
                menuVwItems.Add(vwItem);
            }

            return menuVwItems;
        }
    }
}