using MediatR;
using TableUp.Application.Common;

namespace TableUp.Application.Commands.Restaurants.Update
{
    public class UpdateRestaurantCommand : IRequest<Result>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
