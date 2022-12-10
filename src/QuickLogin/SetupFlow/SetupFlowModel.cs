using System.Text.Json.Serialization;

namespace QuickLogin.SetupFlow;

public class SetupFlowModel
{
    [JsonPropertyName("idp")]       public string IdentityProvider { get; init; }
    [JsonPropertyName("sub")]       public string SubjectId        { get; init; }
    [JsonPropertyName("secret")]    public string SecretKey        { get; init; }
    [JsonPropertyName("login_url")] public string LoginUrl         { get; init; }

    public SetupFlowModel(string identityProvider, string subjectId, string secretKey, string loginUrl)
    {
        IdentityProvider = identityProvider;
        SubjectId        = subjectId;
        SecretKey        = secretKey;
        LoginUrl         = loginUrl;
    }
}