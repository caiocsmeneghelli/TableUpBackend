using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Tables.Create
{
    public class CreateTableCommand : IRequest<Result>
    {
        public string TableNumber { get; set; } = string.Empty;
    }
}
