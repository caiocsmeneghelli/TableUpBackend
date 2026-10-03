using MediatR;
using TableUp.Application.Common;
using TableUp.Application.Services;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.Restaurants.Inactive
{
    public class InactiveRestaurantCommandHandler : IRequestHandler<InactiveRestaurantCommand, Result>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IOrderBillRepository _orderBillRepository;
        private readonly ICurrentUserService _currentUserService;

        public InactiveRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository,
            ITableRepository tableRepository,
            IMenuCategoryRepository menuCategoryRepository,
            IMenuItemRepository menuItemRepository,
            IOrderBillRepository orderBillRepository,
            ICurrentUserService currentUserService)
        {
            _restaurantRepository = restaurantRepository;
            _tableRepository = tableRepository;
            _menuCategoryRepository = menuCategoryRepository;
            _menuItemRepository = menuItemRepository;
            _orderBillRepository = orderBillRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(InactiveRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(request.Guid);
            if (restaurant == null)
            {
                return Result.Failure("Restaurante não encontrado.");
            }

            Guid userGuid = _currentUserService.UserId;

            restaurant.Deactivate(userGuid);
            await _restaurantRepository.UpdateAsync(restaurant);

            var tables = await _tableRepository.ListActiveByRestaurantAsync(restaurant.Guid);
            foreach (var table in tables)
            {
                table.Deactivate(userGuid);
                await _tableRepository.UpdateAsync(table);
            }

            var categories = await _menuCategoryRepository.ListActiveByRestaurantAsync(restaurant.Guid);
            foreach (var category in categories)
            {
                category.Deactivate(userGuid);
                await _menuCategoryRepository.UpdateAsync(category);
            }

            var categoryGuids = categories.Select(c => c.Guid).ToList();
            var menuItems = await _menuItemRepository.ListActiveByCategoriesAsync(categoryGuids);
            foreach (var menuItem in menuItems)
            {
                menuItem.Deactivate(userGuid);
                await _menuItemRepository.UpdateAsync(menuItem);
            }

            var tableGuids = tables.Select(t => t.Guid).ToList();
            var orderBills = await _orderBillRepository.ListActiveByTablesAsync(tableGuids);
            foreach (var orderBill in orderBills)
            {
                orderBill.Deactivate(userGuid);
                await _orderBillRepository.UpdateAsync(orderBill);
            }

            return Result.Success("Restaurante inativado.");
        }
    }
}
