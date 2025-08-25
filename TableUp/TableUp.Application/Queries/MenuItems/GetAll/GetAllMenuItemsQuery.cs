using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuItems.GetAll
{
    public class GetAllMenuItemsQuery : IRequest<List<MenuItem>>
    {
    }
}
