using MediatR;

namespace TableUp.Application.Commands.MenuCategories.Delete
{
    public class DeleteMenuCategoryCommand : IRequest<bool>
    {
        public Guid Guid { get; private set; }

        public DeleteMenuCategoryCommand(Guid guid)
        {
            Guid = guid;
        }
    }
}
