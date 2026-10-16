using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.MenuCategories
{
    public class MenuCategoryWithItemsViewModel
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public List<MenuCategoryItemViewModel> Items { get; private set; }

        public MenuCategoryWithItemsViewModel(MenuCategory category, IEnumerable<MenuItem> items)
        {
            Guid = category.Guid;
            Name = category.Name;
            Items = items
                .OrderBy(i => i.Name)
                .Select(i => new MenuCategoryItemViewModel(i))
                .ToList();
        }
    }

    public class MenuCategoryItemViewModel
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }

        public MenuCategoryItemViewModel(MenuItem item)
        {
            Guid = item.Guid;
            Name = item.Name;
            Description = item.Description;
            Value = item.Value;
        }
    }
}
