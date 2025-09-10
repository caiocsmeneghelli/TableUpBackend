using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Application.Common;
using TableUp.Domain.Entities;
using TableUp.Domain.Repositories;

namespace TableUp.Application.Commands.MenuCategories.Create
{
    public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, Result>
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly CreateMenuCategoryCommandValidator _validation;

        public CreateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository, CreateMenuCategoryCommandValidator validation)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _validation = validation;
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

            MenuCategory menuCategory = new MenuCategory(request.Name);
            await _menuCategoryRepository.AddAsync(menuCategory);

            return Result.Success(menuCategory.Guid);
        }
    }
}
