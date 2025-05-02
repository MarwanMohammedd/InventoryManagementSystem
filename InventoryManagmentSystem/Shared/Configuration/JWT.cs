namespace InventoryManagmentSystem.Shared.Configuration;

public class JWT
{
    public static string SectionName { get; } = "JWT";
    public string Key { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}