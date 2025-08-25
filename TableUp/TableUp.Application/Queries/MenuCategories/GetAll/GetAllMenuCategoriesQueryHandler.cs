using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuCategories.GetAll
{
    public class GetAllMenuCategoriesQueryHandler : IRequestHandler<GetAllMenuCategoriesQuery, List<MenuCategory>>
    {
        public Task<List<MenuCategory>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = new List<MenuCategory>
            {
                new MenuCategory("Appetizers"),
                new MenuCategory("Main Course"),
                new MenuCategory("Desserts"),
                new MenuCategory("Beverages")
            };
            return Task.FromResult(categories);
        }
    }
}
