using System.Text.Json.Serialization;

namespace QuickLogin.SetupFlow;

public class SetupQrCodeModel
{
    [JsonPropertyName("method")] public string Method   { get; init; }
    [JsonPropertyName("url")]    public string SetupUrl { get; init; }

    public SetupQrCodeModel(string setupUrl)
    {
        Method   = QrCodeMethod.Setup;
        SetupUrl = setupUrl;
    }
}