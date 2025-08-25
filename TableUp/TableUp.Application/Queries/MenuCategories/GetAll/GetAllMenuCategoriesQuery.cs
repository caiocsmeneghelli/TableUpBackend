using MediatR;
using TableUp.Domain.Entities;

namespace TableUp.Application.Queries.MenuCategories.GetAll
{
    public class GetAllMenuCategoriesQuery : IRequest<List<MenuCategory>>
    {
    }
}
