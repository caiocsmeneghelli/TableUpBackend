using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Inactive
{
    public class InactiveTableCommandHandler : IRequestHandler<InactiveTableCommand, Result>
    {
        private readonly ITableRepository _tableRepository;
        private readonly ICurrentUserService _currentUserService;

        public InactiveTableCommandHandler(ITableRepository tableRepository, ICurrentUserService currentUserService)
        {
            _tableRepository = tableRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(InactiveTableCommand request, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.GetByIdAsync(request.Guid);
            if (table == null)
            {
                return Result.Failure("Mesa não encontrada.");
            }

            Guid userGuid = _currentUserService.UserId;
            table.Deactivate(userGuid);
            await _tableRepository.UpdateAsync(table);

            return Result.Success("Mesa inativada.");
        }
    }
}
