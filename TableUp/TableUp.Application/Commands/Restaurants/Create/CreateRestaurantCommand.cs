using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Restaurants.Create
{
    public class CreateRestaurantCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
