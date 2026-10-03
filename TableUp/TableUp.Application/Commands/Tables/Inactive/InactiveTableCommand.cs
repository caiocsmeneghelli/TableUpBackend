using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Tables.Inactive
{
    public class InactiveTableCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
    }
}
