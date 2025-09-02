using MediatR;
using TableUp.Application.ViewModels.MenuItems;

namespace TableUp.Application.Queries.MenuItems.GetAllActive
{
    public class GetAllMenuItemActiveQuery : IRequest<List<MenuItemViewModel>>
    {
    }
}