using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Entities;

namespace TableUp.Application.Commands.MenuItems.Create
{
    public class CreateMenuItemCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryGuid { get; set; }
        public Guid UserGuid { get; set; }

        public MenuItem ToDomain()
        {
            return new MenuItem(
                Name,
                Description,
                CategoryGuid,
                Price,
                UserGuid
            );
        }
    }
}