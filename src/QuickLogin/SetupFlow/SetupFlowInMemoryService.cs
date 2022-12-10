using QuickLogin.Configuration;
using QuickLogin.Helpers;

namespace QuickLogin.SetupFlow;

public class SetupFlowInMemoryService : ISetupFlowService
{
    private readonly QuickLoginOptions _options;

    public SetupFlowInMemoryService(QuickLoginOptions options) => _options = options;

    private readonly Dictionary<string, SetupQrCode> _storage = new();

    private DateTime _nextCleanupTime = DateTime.MinValue;

    public string Create(IQuickLoginIdentity identity, Action setupSuccessCallback)
    {
        if (_nextCleanupTime < DateTime.Now)
        {
            _nextCleanupTime = DateTime.Now + _options.CleanupTime;
            foreach (var linkLogin in _storage.Values.Where(x => x.Expired < DateTime.Now))
            {
                _storage.Remove(linkLogin.Code);
            }
        }

        var link = new SetupQrCode(_options.CodeLength,
                                   identity,
                                   DateTime.Now + _options.CodeExpirationTime,
                                   setupSuccessCallback);
        return _storage.TryAdd(link.Code, link)
                   ? QrImage.Create(new SetupQrCodeModel($"{_options.SetupUrl}/{link.Code}"))
                   : string.Empty;
    }

    public SetupQrCode? Get(string code)
        => _storage.TryGetValue(code, out var link) && link.IsActual
               ? link
               : null;
}