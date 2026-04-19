using MediatR;
using TableUp.Application.ViewModels.Tables;

namespace TableUp.Application.Queries.Tables.GetAll
{
    public class GetAllTablesQuery : IRequest<List<TableViewModel>>
    {
    }
}
