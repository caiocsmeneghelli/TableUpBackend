using MediatR;
using TableUp.Application.ViewModels.Tables;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.Tables.GetByToken
{
    public class GetTableByTokenQueryHandler : IRequestHandler<GetTableByTokenQuery, TableSummaryViewModel?>
    {
        private readonly ITableRepository _tableRepository;

        public GetTableByTokenQueryHandler(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<TableSummaryViewModel?> Handle(GetTableByTokenQuery request, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.GetActiveWithRestaurantByTokenAsync(request.TableToken);
            if (table == null)
                return null;

            return new TableSummaryViewModel(table);
        }
    }
}
