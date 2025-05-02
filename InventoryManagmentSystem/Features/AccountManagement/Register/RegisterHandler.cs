using System.Text;
using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InventoryManagmentSystem.Features.AccountManagement.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result<RegisterResponse>>
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IRegisterService registerService;
    private readonly IValidator<RegisterRequest> validator;
    private readonly UserManager<ApplicationUser> userManager;

    public RegisterHandler(SignInManager<ApplicationUser> signInManager , IRegisterService registerService, IValidator<RegisterRequest> validator, UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.registerService = registerService;
        this.validator = validator;
        this.userManager = userManager;
    }

    public async Task<Result<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        StringBuilder error = new();
        if (validator.Validate(request).IsValid)
        {
             if (await userManager.Users.AnyAsync(u => u.Email == request.Email))
            {
                return Result<RegisterResponse>.Failure("Email is already registered");
            }

            if (await userManager.Users.AnyAsync(u => u.UserName == request.UserName))
            {
                return Result<RegisterResponse>.Failure("Username is already taken");
            }
            
            ApplicationUser applciationUser = new()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            IdentityResult identityResult = await userManager.CreateAsync(applciationUser, request.Password);
            if (identityResult.Succeeded)
            {
                if (userManager.Users.Count() == 0)
                {
                    await userManager.AddToRoleAsync(applciationUser, Roles.Admin);
                }
                else
                {
                    await userManager.AddToRoleAsync(applciationUser, Roles.User);
                }

                RegisterResponse registerResponse = new()
                {
                    Token = await registerService.GenerateToken(applciationUser),
                    Message = "User Registeration Successfully"
                };
                await signInManager.SignInAsync(applciationUser, isPersistent: true);
                return Result<RegisterResponse>.Success(registerResponse);
            }
            else
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    error.Append(identityError.Description);
                }
            }
        }
        return Result<RegisterResponse>.Failure(error.ToString());
    }
}