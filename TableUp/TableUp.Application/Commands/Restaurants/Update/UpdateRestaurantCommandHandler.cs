using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Restaurants.Update
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Result>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, ICurrentUserService currentUserService)
        {
            _restaurantRepository = restaurantRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(request.Guid);
            if (restaurant == null)
            {
                return Result.Failure("Restaurante não encontrado.");
            }

            Guid userGuid = _currentUserService.UserId;
            restaurant.Update(request.Name, request.Slug, request.Email, request.Description, userGuid);
            await _restaurantRepository.UpdateAsync(restaurant);

            return Result.Success("Restaurante atualizado.");
        }
    }
}
