using TableUp.Domain.Entities;

namespace TableUp.Application.ViewModels.Tables
{
    public class TableSummaryViewModel
    {
        public Guid TableGuid { get; private set; }
        public string TableNumber { get; private set; }
        public Guid RestaurantGuid { get; private set; }
        public string RestaurantName { get; private set; }

        public TableSummaryViewModel(Table table)
        {
            TableGuid = table.Guid;
            TableNumber = table.Number;
            RestaurantGuid = table.Restaurant.Guid;
            RestaurantName = table.Restaurant.Name;
        }
    }
}
