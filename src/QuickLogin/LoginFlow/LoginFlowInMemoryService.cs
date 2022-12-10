using Microsoft.Extensions.Options;
using QuickLogin.Configuration;
using QuickLogin.Helpers;

namespace QuickLogin.LoginFlow;

public class LoginFlowInMemoryService : ILoginFlowService
{
    private readonly QuickLoginOptions _options;

    public LoginFlowInMemoryService(QuickLoginOptions options) => _options = options;

    private readonly Dictionary<string, LoginQrCode> _storage = new();

    private DateTime _nextCleanupTime = DateTime.MinValue;

    public string Create(string returnUrl, Action<string, string> loginSuccessCallback)
    {
        if (_nextCleanupTime < DateTime.Now)
        {
            _nextCleanupTime = DateTime.Now + _options.CleanupTime;
            foreach (var linkLogin in _storage.Values.Where(x => x.Expired < DateTime.Now))
            {
                _storage.Remove(linkLogin.Code);
            }
        }

        var link = new LoginQrCode(_options.CodeLength,
                                   returnUrl,
                                   DateTime.Now + _options.CodeExpirationTime,
                                   loginSuccessCallback);

        return _storage.TryAdd(link.Code, link)
                   ? QrImage.Create(new LoginQrCodeModel(_options.IdentityProvider, link.Code))
                   : string.Empty;
    }


    public LoginQrCode? Get(string code)
        => _storage.TryGetValue(code, out var link) && link.IsActual
               ? link
               : null;
}