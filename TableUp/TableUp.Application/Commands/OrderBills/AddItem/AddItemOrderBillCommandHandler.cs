using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;
using TableUp.Domain.UnitOfWork;

namespace TableUp.Application.Commands.OrderBills.AddItem
{
    public class AddItemOrderBillCommandHandler : IRequestHandler<AddItemOrderBillCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderBillRepository _orderBillRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IOrderItemRepository _billItemRepository;
        private readonly ICurrentUserService _currentUserService;

        public AddItemOrderBillCommandHandler(IUnitOfWork unitOfWork,
            IOrderBillRepository orderBillRepository,
            IMenuItemRepository menuItemRepository,
            IOrderItemRepository billItemRepository,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _orderBillRepository = orderBillRepository;
            _menuItemRepository = menuItemRepository;
            _billItemRepository = billItemRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(AddItemOrderBillCommand request, CancellationToken cancellationToken)
        {
            // Add validations

            // busca orderBill
            OrderBill? orderBill = await _orderBillRepository.GetByIdAsync(request.GuidOrderBill);
            if (orderBill is null)
            {
                return Result.Failure("OrderBill not found.");
            }

            // busca menuItem
            MenuItem? menuItem = await _menuItemRepository.GetByIdAsync(request.GuidMenuItem);
            if (menuItem is null)
            {
                return Result.Failure("MenuItem not found.");
            }

            // cria orderItem
            Guid userGuid = _currentUserService.UserId;
            OrderItem orderItem = new OrderItem(request.Quantity, menuItem.Guid, orderBill.Guid, userGuid);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // salva orderItem
                await _billItemRepository.AddAsync(orderItem);

                // atualiza orderBill
                orderBill.SetUpdated(userGuid);
                await _orderBillRepository.UpdateAsync(orderBill);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result.Failure($"Error adding item to OrderBill: {ex.Message}");
            }

            return Result.Success(orderItem.Guid);
        }
    }
}
