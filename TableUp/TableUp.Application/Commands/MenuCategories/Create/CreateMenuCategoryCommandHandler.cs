using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public CreateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<Result> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            MenuCategory menuCategory = new MenuCategory(request.Name);
            await _menuCategoryRepository.AddAsync(menuCategory);

            return Result.Success(menuCategory.Guid);
        }
    }
}
