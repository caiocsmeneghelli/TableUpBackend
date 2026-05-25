using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Restaurants.Create
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Result>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, ICurrentUserService currentUserService)
        {
            _restaurantRepository = restaurantRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            // add validation

            Guid userId = _currentUserService.UserId;
            var restaurant = new Restaurant(userId, request.Name, request.Slug, request.Email, request.Description);

            await _restaurantRepository.AddAsync(restaurant);
            return Result.Success(restaurant.Guid);
        }
    }
}
