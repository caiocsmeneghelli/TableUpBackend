using MediatR;
using TableUp.Application.ViewModels.MenuItems;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommand : IRequest<MenuItemViewModel>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryGuid { get; set; }
    }
}