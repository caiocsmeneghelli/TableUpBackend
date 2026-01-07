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

        public CreateOrderBillCommandHandler(IOrderBillRepository orderBillRepository, ICurrentUserService currentUserService, CreateOrderBillCommandValidator validator)
        {
            _orderBillRepository = orderBillRepository;
            _currentUserService = currentUserService;
            _validator = validator;
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

            Guid userGuid = _currentUserService.UserId;
            var orderBill = new OrderBill(request.TableNumber, userGuid);
            await _orderBillRepository.AddAsync(orderBill);
            return Result.Success(orderBill.Guid);
        }
    }
}
