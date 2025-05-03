using FluentValidation;
using InventoryManagmentSystem.Features.CategoryManagement.Commands;

namespace InventoryManagmentSystem.Features.CategoryManagement.Validators;

public class AddCategoryValidator : AbstractValidator<AddCategoryCommandRequest>
{
    public AddCategoryValidator()
    {   
        RuleFor(element=>element.CategoryName)
        .NotEmpty()
        .NotNull()
        .WithMessage("Category Name Must Be Not Null Or Empty");
    }
}