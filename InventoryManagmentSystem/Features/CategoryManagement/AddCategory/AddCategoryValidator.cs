using FluentValidation;

namespace InventoryManagmentSystem.Features.CategoryManagement.AddCategory;

public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
{
    public AddCategoryValidator()
    {   
        RuleFor(element=>element.CategoryName)
        .NotEmpty()
        .NotNull()
        .WithMessage("Category Name Must Be Not Null Or Empty");
    }
}