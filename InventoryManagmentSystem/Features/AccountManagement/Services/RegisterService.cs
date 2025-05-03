using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Shared.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace InventoryManagmentSystem.Features.AccountManagement.Services;

public class RegisterService : IRegisterService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IOptionsMonitor<JWT> options;

    public RegisterService(UserManager<ApplicationUser> userManager, IOptionsMonitor<JWT> options)
    {
        this.userManager = userManager;
        this.options = options;
    }

    public async Task<string> GenerateToken(ApplicationUser user)
    {
        string jti = Guid.NewGuid().ToString();
        string userID = user.Id.ToString();
        var userRoles = await userManager.GetRolesAsync(user);

        List<Claim> claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userID),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,jti)
            };
        if (userRoles != null)
        {
            foreach (var role in userRoles)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }
        }

        SymmetricSecurityKey signKey =
            new(Encoding.UTF8.GetBytes(options.CurrentValue.Key));

        SigningCredentials signingcredential = new SigningCredentials
            (signKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken myToken = new JwtSecurityToken(
            issuer: options.CurrentValue.Issuer,
            audience: options.CurrentValue.Audience,
            claims: claim,
            signingCredentials: signingcredential
            );

        return new JwtSecurityTokenHandler().WriteToken(myToken);
    }
}