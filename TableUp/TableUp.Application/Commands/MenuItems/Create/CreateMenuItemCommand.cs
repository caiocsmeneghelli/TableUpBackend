using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryGuid { get; set; }
    }
}