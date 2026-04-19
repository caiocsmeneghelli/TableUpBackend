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

namespace TableUp.Application.Commands.OrderBills.Create
{
    public class CreateOrderBillCommandHandler : IRequestHandler<CreateOrderBillCommand, Result>
    {
        private readonly IOrderBillRepository _orderBillRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly CreateOrderBillCommandValidator _validator;
        private readonly ITableRepository _tableRepository;

        public CreateOrderBillCommandHandler(IOrderBillRepository orderBillRepository, ICurrentUserService currentUserService, CreateOrderBillCommandValidator validator, ITableRepository tableRepository)
        {
            _orderBillRepository = orderBillRepository;
            _currentUserService = currentUserService;
            _validator = validator;
            _tableRepository = tableRepository;
        }

        public async Task<Result> Handle(CreateOrderBillCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join("; ", errors);
                return Result.Failure(errorMessage);
            }


            // adicionar usuario default para usuario nao logado
            Guid userGuid = _currentUserService.UserId;

            // busca table
            var table = request.TableGuid != Guid.Empty
                ? await _tableRepository.GetByIdAsync(request.TableGuid)
                : await _tableRepository.GetByNumberAsync(request.TableNumber);

            if(table == null)
            {
                return Result.Failure("Mesa não encontrada.");
            }

            var orderBill = new OrderBill(table, userGuid);
            await _orderBillRepository.AddAsync(orderBill);
            return Result.Success(orderBill.Guid);
        }
    }
}
