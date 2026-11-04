namespace Shared.Model;

public class JwtSetting
{
    public const string SectionName = "JwtSetting";

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public int ExpireMinutes { get; set; } = 60;
}
