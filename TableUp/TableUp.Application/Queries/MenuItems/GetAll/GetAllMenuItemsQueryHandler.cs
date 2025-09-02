using MediatR;
using TableUp.Application.ViewModels.MenuItems;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.MenuItems.GetAll
{
    public class GetAllMenuItemsQueryHandler : IRequestHandler<GetAllMenuItemsQuery, List<MenuItemViewModel>>
    {
        private readonly IMenuItemRepository _repository;

        public GetAllMenuItemsQueryHandler(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MenuItemViewModel>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var menuItems = await _repository.ListAllAsync(false);
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
