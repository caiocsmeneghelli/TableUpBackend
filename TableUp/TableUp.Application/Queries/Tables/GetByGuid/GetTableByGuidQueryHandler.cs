using MediatR;
using TableUp.Application.ViewModels.Tables;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.Tables.GetByGuid
{
    public class GetTableByGuidQueryHandler : IRequestHandler<GetTableByGuidQuery, TableSummaryViewModel?>
    {
        private readonly ITableRepository _tableRepository;

        public GetTableByGuidQueryHandler(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<TableSummaryViewModel?> Handle(GetTableByGuidQuery request, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.GetActiveWithRestaurantAsync(request.Guid);
            if (table == null)
                return null;

            return new TableSummaryViewModel(table);
        }
    }
}
