using MediatR;
using TableUp.Application.ViewModels.Tables;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.Tables.GetAll
{
    public class GetAllTableQueryHandler : IRequestHandler<GetAllTablesQuery, List<TableViewModel>>
    {
        private readonly ITableRepository _tableRespository;

        public GetAllTableQueryHandler(ITableRepository tableRespository)
        {
            _tableRespository = tableRespository;
        }

        public async Task<List<TableViewModel>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
        {
            List<Table> listTables = await _tableRespository.ListAllAsync(true);
            return listTables
                .Select(reg => new TableViewModel(reg))
                .ToList();
        }
    }
}
