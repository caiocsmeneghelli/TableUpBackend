using MediatR;
using TableUp.Application.ViewModels.Tables;

namespace TableUp.Application.Queries.Tables.GetByGuid
{
    public class GetTableByGuidQuery : IRequest<TableSummaryViewModel?>
    {
        public Guid Guid { get; private set; }

        public GetTableByGuidQuery(Guid guid)
        {
            Guid = guid;
        }
    }
}
