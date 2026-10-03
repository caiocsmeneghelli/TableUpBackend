using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuCategories.Inactive
{
    public class InactiveMenuCategoryCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
    }
}
