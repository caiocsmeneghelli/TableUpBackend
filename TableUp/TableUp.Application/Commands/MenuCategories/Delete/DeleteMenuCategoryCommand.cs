using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuCategories.Delete
{
    public class DeleteMenuCategoryCommand : IRequest<Result>
    {
        public Guid Guid { get; private set; }

        public DeleteMenuCategoryCommand(Guid guid)
        {
            Guid = guid;
        }
    }
}
