using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommand : IRequest<Result>
    {
        public string? Name { get; set; }
    }
}
