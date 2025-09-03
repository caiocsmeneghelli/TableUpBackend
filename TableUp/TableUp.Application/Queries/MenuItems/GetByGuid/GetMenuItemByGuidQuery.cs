using MediatR;
using TableUp.Application.ViewModels.MenuItems;

namespace TableUp.Application.Queries.MenuItems.GetByGuid
{
    public class GetMenuItemByGuidQuery : IRequest<MenuItemViewModel?>
    {
        public Guid Guid { get; }

        public GetMenuItemByGuidQuery(Guid guid)
        {
            Guid = guid;
        }
    }
}