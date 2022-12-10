using System.Text.Json.Serialization;

namespace QuickLogin.LoginFlow;

public class LoginQrCodeModel
{
    [JsonPropertyName("method")] public string Method           { get; init; }
    [JsonPropertyName("idp")]    public string IdentityProvider { get; init; }
    [JsonPropertyName("code")]   public string Code             { get; init; }

    public LoginQrCodeModel(string identityProvider, string code)
    {
        Method           = QrCodeMethod.Login;
        IdentityProvider = identityProvider;
        Code             = code;
    }
}