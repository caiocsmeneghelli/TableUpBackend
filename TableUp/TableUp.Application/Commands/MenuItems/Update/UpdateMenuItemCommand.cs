using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.MenuItems.Update
{
    public class UpdateMenuItemCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CategoryGuid { get; set; }
        public decimal Value { get; set; }
    }
}
