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
        private readonly ITableRepository _tableRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly AddItemOrderBillCommandValidator _validator;

        public AddItemOrderBillCommandHandler(IUnitOfWork unitOfWork,
            IOrderBillRepository orderBillRepository,
            IMenuItemRepository menuItemRepository,
            IOrderItemRepository billItemRepository,
            ICurrentUserService currentUserService,
            AddItemOrderBillCommandValidator validator,
            ITableRepository tableRepository)
        {
            _unitOfWork = unitOfWork;
            _orderBillRepository = orderBillRepository;
            _menuItemRepository = menuItemRepository;
            _billItemRepository = billItemRepository;
            _currentUserService = currentUserService;
            _validator = validator;
            _tableRepository = tableRepository;
        }

        public async Task<Result> Handle(AddItemOrderBillCommand request, CancellationToken cancellationToken)
        {
            // Add validations
            //var validationResult = _validator.Validate(request);
            //if (!validationResult.IsValid)
            //{
            //    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            //    string errorMessage = string.Join("; ", errors);
            //    return Result.Failure(errorMessage);
            //}

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                // buscar orderBill, se não existir, criar um novo
                var orderBill = await _orderBillRepository.GetByTableNumberAsync(request.TableNumber);
                if (orderBill is null)
                {
                    Table? table = await _tableRepository.GetByNumberAsync(request.TableNumber);
                    if (table is null)
                    {
                        return Result.Failure($"Table with number {request.TableNumber} not found.");
                    }


                    orderBill = new OrderBill(table, _currentUserService.UserId);
                    await _orderBillRepository.AddAsync(orderBill);
                }

                // criar lista de orderItems
                foreach (var item in request.Items)
                {
                    MenuItem? menuItem = await _menuItemRepository.GetByIdAsync(item.MenuItemGuid);
                    var orderItem = new OrderItem(item.Quantity, menuItem.Guid, orderBill.Guid, _currentUserService.UserId);
                    await _billItemRepository.AddAsync(orderItem);
                }

                await _unitOfWork.CommitAsync();
                return Result.Success(orderBill.Guid);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result.Failure($"An error occurred while adding items to the order bill: {ex.Message}");
            }
        }
    }
}
