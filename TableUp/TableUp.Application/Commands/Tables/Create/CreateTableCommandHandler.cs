using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Tables.Create
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Result>
    {
        private readonly ITableRepository _tableRepository;
        private readonly CreateTableCommandValidator _validator;
        private readonly ICurrentUserService _currentUserService;

        public CreateTableCommandHandler(ITableRepository tableRepository, 
            ICurrentUserService currentUserService, CreateTableCommandValidator validator)
        {
            _tableRepository = tableRepository;
            _currentUserService = currentUserService;
            _validator = validator;
        }

        public async Task<Result> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            // add validation
            request.Normalize();
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                string errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Failure(errors);
            }

            // busca de usuario logado
            Guid userGuid = _currentUserService.UserId;

            Table table = new Table(userGuid, request.TableNumber);
            Table tableCreated = await _tableRepository.AddAsync(table);
            Guid tableGuid = tableCreated.Guid;

            return Result.Success(tableGuid);
        }
    }
}
