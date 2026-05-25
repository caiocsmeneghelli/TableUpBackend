using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.Restaurants
{
    public class RestaurantsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public void FromEntity(Restaurant restaurant)
        {
            Id = restaurant.Guid;
            Name = restaurant.Name;
            Description = restaurant.Description;
            ImageUrl = restaurant.ImageUrl;
        }
    }
}
