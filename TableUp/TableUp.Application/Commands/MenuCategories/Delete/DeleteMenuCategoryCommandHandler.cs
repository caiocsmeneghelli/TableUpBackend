using MediatR;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Delete
{
    public class DeleteMenuCategoryCommandHandler : IRequestHandler<DeleteMenuCategoryCommand, bool>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public DeleteMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public Task<bool> Handle(DeleteMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var menuCategory = _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (menuCategory.Result == null)
            {
                return Task.FromResult(false);
            }
            _menuCategoryRepository.DeleteAsync(menuCategory.Result);
            return Task.FromResult(true);
        }
    }
}
