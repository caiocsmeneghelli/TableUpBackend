using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string ImageUrl { get; private set; } = string.Empty;

        public Restaurant(Guid userGuid, string name, string slug, string email)
        {
            Name = name;
            Slug = slug;
            Email = email;
            SetCreated(userGuid);
        }

        public void UpdateImageUrl(string imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }
}
