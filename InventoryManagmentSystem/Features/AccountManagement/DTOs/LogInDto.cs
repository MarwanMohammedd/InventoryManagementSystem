using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Features.AccountManagement.DTOs;

public class LogInDto
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public bool RemeberMe { get; set; } = false;
}