using QuickLogin.Helpers;

namespace QuickLogin.SetupFlow;

//public class SetupQrCode: SetupQrCode<string>

public class SetupQrCode
{
    public IQuickLoginIdentity Identity { get; init; }
    public string Code { get; init; }
    public DateTime Expired { get; init; }
    public Action SetupSuccessCallback { get; init; }

    public bool IsActual => Expired > DateTime.Now;

    public SetupQrCode(byte codeLength, IQuickLoginIdentity identity, DateTime expired, Action setupSuccessCallback)
    {
        Identity = identity;
        Code = RandomGenerator.CreateString(codeLength);
        Expired = expired;
        SetupSuccessCallback = setupSuccessCallback;
    }
}