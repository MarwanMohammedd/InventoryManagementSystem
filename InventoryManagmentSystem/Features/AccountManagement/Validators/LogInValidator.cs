using FluentValidation;
using InventoryManagmentSystem.Features.AccountManagement.Commands.LogIn;

namespace InventoryManagmentSystem.Features.AccountManagement.Validators;

public class LogInValidator : AbstractValidator<LogInCommandRequest>
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