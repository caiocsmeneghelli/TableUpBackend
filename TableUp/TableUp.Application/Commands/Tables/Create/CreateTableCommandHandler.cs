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
        private readonly ICurrentUserService _currentUserService;

        public CreateTableCommandHandler(ITableRepository tableRepository, ICurrentUserService currentUserService)
        {
            _tableRepository = tableRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            // add validation

            // verificar se mesa ja foi criada
            Table? tableExists = await _tableRepository.GetByNumberAsync(request.TableNumber);
            if(tableExists != null) { return Result.Failure(string.Format("Mesa {0} já existe.", request.TableNumber)); }

            // busca de usuario logado
            Guid userGuid = _currentUserService.UserId;

            Table table = new Table(userGuid, request.TableNumber);
            Table tableCreated = await _tableRepository.AddAsync(table);
            Guid tableGuid = tableCreated.Guid;

            return Result.Success(tableGuid);
        }
    }
}
