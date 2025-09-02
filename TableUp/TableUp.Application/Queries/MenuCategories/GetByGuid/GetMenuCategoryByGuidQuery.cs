using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.ViewModels.MenuCategories;

namespace TableUp.Application.Queries.MenuCategories.GetByGuid
{
    public class GetMenuCategoryByGuidQuery : IRequest<MenuCategoryViewModel>
    {
        public Guid Guid { get; private set; }

        public GetMenuCategoryByGuidQuery(Guid guid)
        {
            Guid = guid;
        }
    }
}
