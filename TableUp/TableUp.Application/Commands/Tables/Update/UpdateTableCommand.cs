using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Tables.Update
{
    public class UpdateTableCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
        public string TableNumber { get; set; } = string.Empty;

        public void Normalize()
        {
            TableNumber = TableNumber.PadLeft(3, '0');
        }
    }
}
