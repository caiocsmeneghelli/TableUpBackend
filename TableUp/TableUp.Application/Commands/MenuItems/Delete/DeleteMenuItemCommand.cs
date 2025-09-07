using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.MenuItems.Delete
{
    public class DeleteMenuItemCommand : IRequest<bool>
    {
        public Guid Guid { get; private set; }

        public DeleteMenuItemCommand(Guid guid)
        {
            Guid = guid;
        }
    }
}
