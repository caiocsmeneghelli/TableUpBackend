using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Commands.OrderBills.Close;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.OrderBills.CloseCancel
{
    public class CloseCancelOrderBillCommandHandler : IRequestHandler<CloseCancelOrderBillCommand, Result>
    {
        private readonly IOrderBillRepository _repository;
        private readonly ICurrentUserService _currentUserService;


        public CloseCancelOrderBillCommandHandler(IOrderBillRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CloseCancelOrderBillCommand request, CancellationToken cancellationToken)
        {
            OrderBill? orderBill = await _repository.GetByIdAsync(request.Guid);
            if (orderBill == null) { return Result.Failure("OrderBill não encontrado."); }

            Guid userGuid = _currentUserService.UserId;

            switch (request.Status)
            {
                case EStatusOrderBill.Canceled:
                    orderBill.Deactivate(userGuid);
                    await _repository.UpdateAsync(orderBill);
                    return Result.Success("OrderBill cancelada.");
                    break;
                case EStatusOrderBill.Closed:
                    orderBill.CloseBill(userGuid);
                    await _repository.UpdateAsync(orderBill);
                    return Result.Success("OrderBill fechada.");
                    break;
                default:
                    return Result.Failure("Status inválido para fechamento ou cancelamento.");
                    break;
            }
        }
    }
}
