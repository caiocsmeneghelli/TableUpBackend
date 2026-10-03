using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuCategories.Update
{
    public class UpdateMenuCategoryCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid RestaurantGuid { get; set; }
    }
}
