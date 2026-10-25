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
                    if (!orderBill.CanCancel) { return Result.Failure("Apenas contas abertas ou fechadas podem ser canceladas."); }
                    orderBill.Deactivate(userGuid);
                    await _repository.UpdateAsync(orderBill);
                    return Result.Success("OrderBill cancelada.");
                    break;
                case EStatusOrderBill.Closed:
                    if (!orderBill.CanClose) { return Result.Failure("OrderBill não está aberta."); }
                    orderBill.CloseBill(userGuid);
                    await _repository.UpdateAsync(orderBill);
                    return Result.Success("OrderBill fechada.");
                    break;
                case EStatusOrderBill.Paid:
                    if (!orderBill.CanPay) { return Result.Failure("Apenas contas fechadas podem ser marcadas como pagas."); }
                    orderBill.Pay(userGuid);
                    await _repository.UpdateAsync(orderBill);
                    return Result.Success("OrderBill paga.");
                    break;
                default:
                    return Result.Failure("Status inválido para fechamento ou cancelamento.");
                    break;
            }
        }
    }
}
