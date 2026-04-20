using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Tables.Create
{
    public class CreateTableCommand : IRequest<Result>
    {
        public string TableNumber { get; set; } = string.Empty;

        public void Normalize()
        {
            TableNumber = TableNumber.PadLeft(3, '0');
        }
    }
}
