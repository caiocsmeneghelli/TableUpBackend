using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Update
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, Result>
    {
        private readonly ITableRepository _tableRepository;
        private readonly UpdateTableCommandValidator _validator;
        private readonly ICurrentUserService _currentUserService;

        public UpdateTableCommandHandler(ITableRepository tableRepository, UpdateTableCommandValidator validator,
            ICurrentUserService currentUserService)
        {
            _tableRepository = tableRepository;
            _validator = validator;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            request.Normalize();
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                string errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Failure(errors);
            }

            var table = await _tableRepository.GetByIdAsync(request.Guid);
            if (table == null)
            {
                return Result.Failure("Mesa não encontrada.");
            }

            Guid userGuid = _currentUserService.UserId;
            table.Update(request.TableNumber, userGuid);
            await _tableRepository.UpdateAsync(table);

            return Result.Success("Mesa atualizada.");
        }
    }
}
