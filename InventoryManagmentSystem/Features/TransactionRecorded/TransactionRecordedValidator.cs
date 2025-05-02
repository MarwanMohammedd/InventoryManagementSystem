using FluentValidation;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedValidator : AbstractValidator<TransactionRecordedNotification>
{
    public TransactionRecordedValidator()
    {
        RuleFor(element => element.UserId)
        .NotEmpty()
        .WithMessage("User ID is Not Valid");
        RuleFor(element => element.ProductId)
        .NotEmpty()
        .WithMessage("Product ID is Not Valid");
        RuleFor(element => element.UserName)
        .NotEmpty()
        .NotNull()
        .WithMessage("User Name is Not Valid");
        RuleFor(element => element.ProductCategory)
        .NotEmpty()
        .NotNull()
        .WithMessage("Product Category Name is Not Valid");
        RuleFor(element => element.Quantity)
        .NotEmpty()
        .WithMessage("Quantity is Not Valid");
    }
}