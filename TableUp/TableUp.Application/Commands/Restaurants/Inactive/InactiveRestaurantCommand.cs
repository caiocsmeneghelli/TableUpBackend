using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Restaurants.Inactive
{
    public class InactiveRestaurantCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
    }
}