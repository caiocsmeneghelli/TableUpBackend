using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuItems.Delete
{
    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, Result>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public DeleteMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Result> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemMenu = await _menuItemRepository.GetByIdAsync(request.Guid);
                if (itemMenu == null) return Result.Failure("Item não encontrado.");

                await _menuItemRepository.DeleteAsync(itemMenu);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
