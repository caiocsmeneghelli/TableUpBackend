using MediatR;
using TableUp.Application.ViewModels.MenuCategories;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuCategories.GetAll
{
    public class GetAllMenuCategoriesQuery : IRequest<List<MenuCategoryViewModel>>
    {
        public bool Active { get; private set; }

        public GetAllMenuCategoriesQuery()
        { }

        public GetAllMenuCategoriesQuery(bool active)
        {
            Active = active;
        }
    }
}
