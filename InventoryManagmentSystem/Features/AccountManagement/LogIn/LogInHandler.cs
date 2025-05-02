using System.Text;
using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagmentSystem.Features.AccountManagement.LogIn;

public class LogInHandler : IRequestHandler<LogInOperationRequest, Result<string>>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IValidator<LogInOperationRequest> validator;
    private readonly SignInManager<ApplicationUser> signInManager;

    public LogInHandler(UserManager<ApplicationUser> userManager, IValidator<LogInOperationRequest> validator, SignInManager<ApplicationUser> signInManager)
    {
        this.userManager = userManager;
        this.validator = validator;
        this.signInManager = signInManager;
    }
    public async Task<Result<string>> Handle(LogInOperationRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return Result<string>.Failure("User not found");
            }
            
            SignInResult signInResult = await signInManager.PasswordSignInAsync(user.UserName, request.Password, isPersistent: request.RemeberMe, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                return Result<string>.Success("User Log In Successfully");
            }
            else
            {
                return Result<string>.Failure("Log In Operation Is Faild");
            }

        }
        return Result<string>.Failure("User Log In Credintial Is Not Valid");
    }
}