using MediatR;
using TableUp.Application.ViewModels.Tables;

namespace TableUp.Application.Queries.Tables.GetByToken
{
    public class GetTableByTokenQuery : IRequest<TableSummaryViewModel?>
    {
        public string TableToken { get; private set; }

        public GetTableByTokenQuery(string tableToken)
        {
            TableToken = tableToken;
        }
    }
}
