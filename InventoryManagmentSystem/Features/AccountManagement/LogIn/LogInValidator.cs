using FluentValidation;

namespace InventoryManagmentSystem.Features.AccountManagement.LogIn;

public class LogInValidator : AbstractValidator<LogInOperationRequest>
{
    public LogInValidator()
    {
        RuleFor(e=>e.Email)
        .NotEmpty()
        .NotNull()
        .WithMessage("User Name is not valid");
    
        RuleFor(e=>e.Password)
        .NotEmpty()
        .NotNull()
        .WithMessage("Password is not valid");
    }
}