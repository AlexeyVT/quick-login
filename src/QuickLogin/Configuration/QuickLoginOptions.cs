namespace QuickLogin.Configuration;

public class QuickLoginOptions
{
    public TimeSpan CodeExpirationTime { get; set; } = TimeSpan.FromMinutes(1);
    public string   LoginUrl           { get; set; } = string.Empty; //for example, "https://foo.bar/qrcode/login"
    public string   SetupUrl           { get; set; } = string.Empty; //for example, "https://foo.bar/qrcode/setup"
    public string   IdentityProvider   { get; set; } = "localhost";
    public byte     CodeLength         { get; set; } = 48;
    public TimeSpan CleanupTime        { get; set; } = TimeSpan.FromMinutes(1);
}