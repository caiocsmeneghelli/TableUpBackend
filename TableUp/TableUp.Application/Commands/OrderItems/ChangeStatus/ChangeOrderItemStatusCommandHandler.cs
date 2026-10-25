using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Entities;
using TableUp.Domain.Enums;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.OrderItems.ChangeStatus
{
    public class ChangeOrderItemStatusCommandHandler : IRequestHandler<ChangeOrderItemStatusCommand, Result>
    {
        private readonly IOrderItemRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public ChangeOrderItemStatusCommandHandler(IOrderItemRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(ChangeOrderItemStatusCommand request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await _repository.GetByIdAsync(request.Guid);
            if (orderItem == null) { return Result.Failure("OrderItem não encontrado."); }

            Guid userGuid = _currentUserService.UserId;

            switch (request.Status)
            {
                case EStatusOrderItem.Completd:
                    if (!orderItem.CanComplete) { return Result.Failure("Apenas itens pendentes podem ser completados."); }
                    orderItem.CompleteOrderItem(userGuid);
                    await _repository.UpdateAsync(orderItem);
                    return Result.Success("OrderItem completado.");
                case EStatusOrderItem.Canceled:
                    if (!orderItem.CanCancel) { return Result.Failure("OrderItem já está cancelado."); }
                    orderItem.CancelOrderItem(userGuid);
                    await _repository.UpdateAsync(orderItem);
                    return Result.Success("OrderItem cancelado.");
                default:
                    return Result.Failure("Status inválido para o item.");
            }
        }
    }
}
