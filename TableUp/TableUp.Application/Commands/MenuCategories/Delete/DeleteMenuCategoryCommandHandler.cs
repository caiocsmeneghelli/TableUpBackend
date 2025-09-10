using MediatR;
using TableUp.Application.Common;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Delete
{
    public class DeleteMenuCategoryCommandHandler : IRequestHandler<DeleteMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public DeleteMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<Result> Handle(DeleteMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var menuCategory = await _menuCategoryRepository.GetByIdAsync(request.Guid);
            if (menuCategory == null)
            {
                return Result.Failure("Menu category not found");
            }
            await _menuCategoryRepository.DeleteAsync(menuCategory);
            return Result.Success();
        }
    }
}
