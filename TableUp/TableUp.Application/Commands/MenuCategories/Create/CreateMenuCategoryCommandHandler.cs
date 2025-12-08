using FluentValidation;
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

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly CreateMenuCategoryCommandValidator _validation;

        public CreateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository, CreateMenuCategoryCommandValidator validation,
            ICurrentUserService currentUserService)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _validation = validation;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validation.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join("; ", errors);
                return Result.Failure(errorMessage);
            }

            Guid guid = _currentUserService.UserId;
            MenuCategory menuCategory = new MenuCategory(request.Name, guid);
            await _menuCategoryRepository.AddAsync(menuCategory);

            return Result.Success(menuCategory.Guid);
        }
    }
}
