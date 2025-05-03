using FluentValidation;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedValidator : AbstractValidator<TransactionRecordedRequest>
{
    public TransactionRecordedValidator()
    {
        RuleFor(element => element.UserId)
        .NotEmpty()
        .WithMessage("User ID is Not Valid");
        RuleFor(element => element.ProductId)
        .NotEmpty()
        .WithMessage("Product ID is Not Valid");
        RuleFor(element => element.Quantity)
        .NotEmpty()
        .WithMessage("Quantity is Not Valid");
    }
}