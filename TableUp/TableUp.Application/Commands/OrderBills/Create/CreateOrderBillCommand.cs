using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.OrderBills.Create
{
    public class CreateOrderBillCommand : IRequest<Result>
    {
        public string TableNumber { get; set; } = string.Empty;
    }
}
