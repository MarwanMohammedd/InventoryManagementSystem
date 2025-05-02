using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Features.AccountManagement.Register;

public class RegisterDto
{
    [Required]
    public string FirstName { get; set;}
    [Required]
    public string LastName { get; set;}
    [Required]
    [EmailAddress]
    public string Email { get; set;}
    public string UserName { get; set;}
    [DataType(dataType: DataType.Password)]
    public string Password { get; set;}

    [DataType(dataType: DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set;}
}