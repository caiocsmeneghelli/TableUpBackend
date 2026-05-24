using MediatR;
using TableUp.Application.ViewModels.Restaurants;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Queries.Restaurants.GetAll
{
    public class GetAllRestaurantQueryHandler : IRequestHandler<GetAllRestaurantQuery, List<RestaurantsViewModel>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetAllRestaurantQueryHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<RestaurantsViewModel>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            var result = await _restaurantRepository.ListAllAsync(request.Active);
            var listVw = new List<RestaurantsViewModel>();
            foreach (var item in result)
            {
                var vm = new RestaurantsViewModel();
                vm.FromEntity(item);
                listVw.Add(vm);
            }
            return listVw;
        }
    }
}
