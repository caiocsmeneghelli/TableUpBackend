using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, bool>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemRepository, IMenuCategoryRepository menuCategoryRepository)
        {
            _menuItemRepository = menuItemRepository;
            _menuCategoryRepository = menuCategoryRepository;
        }
        public async Task<bool> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemMenu = await _menuItemRepository.GetByIdAsync(request.Guid);
                if (itemMenu == null) return false;

                var itemCategory = await _menuCategoryRepository.GetByIdAsync(request.CategoryGuid);
                if (itemCategory == null || itemCategory.Status != Domain.Enums.EStatus.Active) return false;

                itemMenu.Update(request.Name, request.Description, request.CategoryGuid, request.Value);
                await _menuItemRepository.UpdateAsync(itemMenu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
