using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
    }
}
