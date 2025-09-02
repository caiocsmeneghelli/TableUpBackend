using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, Guid>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public CreateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public Task<Guid> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            MenuCategory menuCategory = new MenuCategory(request.Name);
            _menuCategoryRepository.AddAsync(menuCategory);

            return Task.FromResult(menuCategory.Guid);
        }
    }
}
