using FluentValidation;
using InventoryManagmentSystem.Features.AccountManagement.Commands.Register;

namespace InventoryManagmentSystem.Features.AccountManagement.Validators;

public class RegisterValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterValidator()
    {
        RuleFor(e => e.Email)
        .NotNull()
        .NotEmpty()
        .WithMessage("Email Is Not Valid");
        RuleFor(e => e.FirstName)
        .NotNull()
        .NotEmpty()
        .WithMessage("FirstName Is Not Valid");
        RuleFor(e => e.LastName)
        .NotNull()
        .NotEmpty()
        .WithMessage("LastName Is Not Valid");
        RuleFor(e => e.UserName)
        .NotNull()
        .NotEmpty()
        .WithMessage("UserName Is Not Valid");
        RuleFor(e => e.Password)
        .NotNull()
        .NotEmpty()
        .WithMessage("Password Is Not Valid");
    }
}