using MediatR;
using TableUp.Application.ViewModels.Restaurants;

namespace TableUp.Application.Queries.Restaurants.GetAll
{
    public class GetAllRestaurantQuery : IRequest<List<RestaurantsViewModel>>
    {
        public bool Active { get; set; }
        public GetAllRestaurantQuery(bool active)
        {
            Active= active;
        }
    }
}
