using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommand : IRequest<Result>
    {
        public string? Name { get; set; } = string.Empty;
    }
}
