namespace ShopApp.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string? Secrets { get; set; } = null!;
    public int ExpirayMinute { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
}

